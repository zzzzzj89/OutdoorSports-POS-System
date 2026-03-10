using Outdoor.BLL;
using Outdoor.DAL;
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
    public partial class FrmCashier : Form
    {

        private BindingList<CartItem> _carList = new BindingList<CartItem>();
        private ProductDAL _productDAL = new ProductDAL();
        private OrderDAL _orderDAL = new OrderDAL();
        private PromotionService _promoService = new PromotionService();

        public FrmCashier()
        {
            InitializeComponent();
            dgvCart.DataSource = _carList;
        }

        private void FrmCashier_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvCart);
         
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(barcode)) return;

                var product = _productDAL.GetProducts(barcode).FirstOrDefault();

                if (product != null)
                {
                    AddtoCart(product);
                    txtBarcode.Clear();
                }
                else
                {
                    MessageBox.Show("未找到商品");
                    txtBarcode.SelectAll();
                }
            }
        }

        private void AddtoCart(BaseProduct product)
        {
            // --- [New!] 检查促销 ---
            string promoTag = "";
            decimal finalPrice = product.UnitPrice;

            // 调用服务计算折后价
            decimal discountedPrice = _promoService.GetDiscountedPrice(product.ProductId, product.UnitPrice, out string promoName);

            if (discountedPrice < product.UnitPrice)
            {
                finalPrice = discountedPrice;
                promoTag = $"[{promoName}]"; // 标记一下，比如 "[五一特惠]"
            }
            // -----------------------

            // 判断购物车里是否已有
            var existingItem = _carList.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
                // 注意：如果之前加的时候没打折，现在突然打折了，逻辑会比较复杂
                // 毕设简单处理：假设一次结算中价格不变，更新为最新价格
                existingItem.Price = finalPrice;
            }
            else
            {
                _carList.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Barcode = product.Barcode,
                    // 拼接一下商品名，让收银员看到打折了： "冲锋衣 [八折特惠]"
                    ProductName = product.ProductName + (string.IsNullOrEmpty(promoTag) ? "" : " " + promoTag),
                    Price = finalPrice, // 使用折后价！
                    Quantity = 1
                });
            }

            dgvCart.Refresh();
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = _carList.Sum(x => x.SubTotal);
            lblTotal.Text = $"￥{total:F2}";
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (_carList.Count == 0) return;
            
            List<SalesOrderDetail> details = new List<SalesOrderDetail>();
            foreach(var item in _carList)
            {
                details.Add(new SalesOrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    SalePrice = item.Price,
                    Subtotal = item.SubTotal

                });
            }

            string error;
            bool isSuccess = _orderDAL.CreateOrder(details, "Cash", null, out error);

            if (isSuccess)
            {
                MessageBox.Show(" 结算成功！");
                _carList.Clear();
                UpdateTotal();
            }
            else
            {
                MessageBox.Show("结算失败：{error}\n");
            }
             
                    
                
        }
    }
}
