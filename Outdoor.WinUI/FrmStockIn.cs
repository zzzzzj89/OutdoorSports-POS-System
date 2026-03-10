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
using Outdoor.Models;

namespace Outdoor.WinUI
{
    public partial class FrmStockIn : Form
    {

        private ProductService _productService = new ProductService();
        private StockService _stockService = new StockService();
        private BaseProduct _selectProduct = null;
        public FrmStockIn()
        {
            InitializeComponent();
            dgvPrducts.AutoGenerateColumns = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmStockIn_Load(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgvPrducts.DataSource = _productService
                .GetAllProducts(txtSearch.Text.Trim());

        }

        private void dgvPrducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _selectProduct = dgvPrducts.Rows[e.RowIndex].DataBoundItem as BaseProduct;

            if (_selectProduct != null)
            {
                lblProductName.Text = _selectProduct.ProductName;

                int currentStock =
                    _stockService.GetCurrentStock(GlobalContext.CurrentStore.StoreId,
                    _selectProduct.ProductId);

                lblCurrentStock.Text = currentStock.ToString();
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectProduct == null)
            {
                MessageBox.Show("请先在左侧选择一个商品");
                return;
            }

            int qty = (int)numQuantity.Value;

            if (_stockService.StockIn( GlobalContext.CurrentStore.StoreId,
                _selectProduct.ProductId, qty, GlobalContext.CurrentUser.RealName, out string msg))
            {
                MessageBox.Show($"成功入库!\n 商品：{_selectProduct.ProductName}" +
                    $"\n新增数量：{qty}");
                int newStock = _stockService.GetCurrentStock(GlobalContext.CurrentStore.StoreId, _selectProduct.ProductId);
                lblCurrentStock.Text = newStock.ToString();

                // 重置输入框
                numQuantity.Value = 1;
            }
            else
            {
                MessageBox.Show(msg);
            }

        }
    }
}
