using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outdoor.BLL;
using Outdoor.DAL.Models;

namespace Outdoor.WinUI
{
    public partial class FrmPromotion : Form
    {

        private PromotionService _promoService = new PromotionService();
        private ProductService _productService = new ProductService(); // 为了加载商品下拉框
        public FrmPromotion()
        {
            InitializeComponent();
            UIHelper.StyleForm(this);
            UIHelper.StyleDataGridView(dgvPromos);
        }

        private void FrmPromotion_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadList();
        }

        // 加载商品下拉框
        private void LoadProducts()
        {
            var list = _productService.GetAllProducts("");
            cmbProducts.DataSource = list;
            cmbProducts.DisplayMember = "ProductName"; // 显示名称
            cmbProducts.ValueMember = "ProductId";     // 值为ID
        }

        // 加载列表
        private void LoadList()
        {
            dgvPromos.DataSource = _promoService.GetList();
            // 隐藏不想看的列
            if (dgvPromos.Columns["Product"] != null) dgvPromos.Columns["Product"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedValue == null) return;

            if (!decimal.TryParse(txtRate.Text, out decimal rate))
            {
                MessageBox.Show("折扣率请输入数字（如 0.8）");
                return;
            }

            var promo = new SysPromotion
            {
                PromoName = txtName.Text.Trim(),
                ProductId = (int)cmbProducts.SelectedValue,
                DiscountRate = rate,
                StartTime = dtpStart.Value,
                EndTime = dtpEnd.Value,
                IsActive = 1
            };

            if (_promoService.AddPromotion(promo, out string msg))
            {
                MessageBox.Show("活动发布成功！");
                LoadList();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }
    }
}
