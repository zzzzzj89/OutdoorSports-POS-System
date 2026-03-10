using Outdoor.BLL;
using Outdoor.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outdoor.WinUI
{
    public partial class FrmProductEdit : Form
    {

        private ProductService _productService = new ProductService();
        private int _productId = 0;


        public FrmProductEdit(int productId = 0)
        {
            InitializeComponent();
            _productId = productId;
        }



        private void FrmProductEdit_Load(object sender, EventArgs e)
        {
            if (_productId > 0) 
            {
                this.Text = "修改商品";
                var p = _productService.GetProductById(_productId);
                if (p != null)
                {
                    txtName.Text = p.ProductName;
                    txtBarcode.Text = p.Barcode;
                    txtCategory.Text = p.Category;
                    txtPrice.Text = p.UnitPrice.ToString();
                    // 条码通常不允许修改，为了安全可以设为只读
                    txtBarcode.ReadOnly = true;
                }
                else
                {
                    this.Text = "新增商品";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 简单的输入校验
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("价格必须是数字！");
                return;
            }

            // 2. 封装对象
            // 注意：这里我们创建一个新对象，或者复用旧ID
            BaseProduct product = new BaseProduct
            {
                ProductId = _productId, // 关键：带上ID去BLL层，Service就知道是修改还是新增
                ProductName = txtName.Text.Trim(),
                Barcode = txtBarcode.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                UnitPrice = price
                // CostPrice 暂时不填，或者你可以在界面上也加一个文本框
            };

            // 3. 调用后台
            if (_productService.SaveProduct(product, out string msg))
            {
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK; // 告诉父窗口“我搞定了”
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败：" + msg);
            }
        }
    }
}
