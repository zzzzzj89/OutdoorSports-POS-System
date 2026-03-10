using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL.Models;

namespace Outdoor.DAL
{
    public class ProductDAL
    {

        public List<BaseProduct> GetProducts(string keyword = "")
        {
            using(var context = new OutdoorContext())
            {
                var query = context.BaseProducts.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(p=>p.ProductName.Contains(keyword)|| 
                    p.Barcode.Contains(keyword));
                }

                return query.ToList();

            }
        }

        public void AddProduct(BaseProduct product)
        {
            using(var context = new OutdoorContext())
            {
                context.BaseProducts.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(BaseProduct product)
        {
            using(var context = new OutdoorContext())
            {
                context.BaseProducts.Update(product);
                context.SaveChanges();
            }
        }

        public bool IsBarcodeExist(string barcode)
        {
            using(var context = new OutdoorContext())
            {
                return context.BaseProducts.Any(p => p.Barcode == barcode);
            }
        }

        public BaseProduct GeitProductById(int id)
        {
            using (var context = new OutdoorContext())
            {
                return context.BaseProducts.Find(id);
            }
        }

        public void BatchInsertProducts(List<BaseProduct> products)
        {
            using (var context = new OutdoorContext())
            {
                context.BaseProducts.AddRange(products);
                context.SaveChanges();
            }
        }

        // [New!] 获取所有现有的条形码（用于查重）
        public HashSet<string> GetAllBarcodes()
        {
            using (var context = new OutdoorContext())
            {
                // 用 HashSet 查找速度极快
                return context.BaseProducts.Select(p => p.Barcode).ToHashSet();
            }
        }
    }
}
