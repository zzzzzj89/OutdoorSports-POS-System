using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL;
using Outdoor.DAL.Models;
using MiniExcelLibs;


namespace Outdoor.BLL
{
    public class ProductService
    {
        private ProductDAL _productDAL = new ProductDAL();

        public List<BaseProduct> GetAllProducts(string nameOrCode)
        {
            return _productDAL.GetProducts(nameOrCode);
        }

        public BaseProduct GetProductById(int id)
        {
            return _productDAL.GeitProductById(id);
        }

        public bool SaveProduct(BaseProduct product,out string message) 
        {
            message = "";

            if (string.IsNullOrEmpty(product.ProductName) 
                || string.IsNullOrEmpty(product.Barcode))
            {
                message = "商品名称和条形码不能为空";
                return false;
            }

            if (product.ProductId == 0)
            {
                if (_productDAL.IsBarcodeExist(product.Barcode))
                {
                    message = "该条形码已存在";
                    return false;
                }

                _productDAL.AddProduct(product);
            }

            else
            {
                _productDAL.UpdateProduct(product);
            }

            return true;
        }

        // [New!] 导入商品逻辑
        public bool ImportProductsFromExcel(string filePath, out string msg)
        {
            msg = "";

            // 1. 读取 Excel 数据到 DTO 列表
            var rows = MiniExcel.Query<ProductImportDto>(filePath).ToList();

            if (rows.Count == 0)
            {
                msg = "Excel 文件为空！";
                return false;
            }

            // 2. 预先获取数据库里已有的条码 (为了防止插入重复报错)
            var existingBarcodes = _productDAL.GetAllBarcodes();

            List<DAL.Models.BaseProduct> productsToAdd = new List<DAL.Models.BaseProduct>();
            HashSet<string> currentImportBarcodes = new HashSet<string>(); // 记录当前Excel里出现的条码

            int rowIndex = 1; // 记录行号方便报错
            foreach (var row in rows)
            {
                rowIndex++;

                // --- 基础校验 ---
                if (string.IsNullOrWhiteSpace(row.ProductName) || string.IsNullOrWhiteSpace(row.Barcode))
                {
                    msg = $"第 {rowIndex} 行错误：名称和条码不能为空。";
                    return false;
                }

                // --- 查重校验 (数据库) ---
                if (existingBarcodes.Contains(row.Barcode))
                {
                    // 策略：跳过已存在的？还是报错？
                    // 毕设简单点：直接报错，要求用户整理好数据再来
                    msg = $"第 {rowIndex} 行错误：条码 {row.Barcode} 已存在于数据库中。";
                    return false;
                }

                // --- 查重校验 (Excel内部重复) ---
                if (currentImportBarcodes.Contains(row.Barcode))
                {
                    msg = $"第 {rowIndex} 行错误：条码 {row.Barcode} 在 Excel 中重复出现。";
                    return false;
                }

                currentImportBarcodes.Add(row.Barcode);

                // --- 转换实体 ---
                productsToAdd.Add(new DAL.Models.BaseProduct
                {
                    ProductName = row.ProductName,
                    Barcode = row.Barcode,
                    Category = row.Category,
                    Brand = row.Brand,
                    UnitPrice = row.UnitPrice,
                    CostPrice = row.CostPrice,
                    Spec = row.Spec
                });
            }

            // 3. 批量保存
            _productDAL.BatchInsertProducts(productsToAdd);

            msg = $"成功导入 {productsToAdd.Count} 条商品数据！";
            return true;
        }



    }



}
