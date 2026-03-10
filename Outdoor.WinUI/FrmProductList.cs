using MiniExcelLibs;
using Outdoor.BLL;
using Outdoor.DAL.Models;

namespace Outdoor.WinUI
{
    public partial class FrmProductList : Form
    {
        ProductService _productService = new ProductService();

        public FrmProductList()
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = true;
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            // 1. 美化窗体背景
            UIHelper.StyleForm(this);

            // 2. 美化表格
            UIHelper.StyleDataGridView(dgvProducts);

            // 3. 美化按钮
            UIHelper.StyleButton(btnQuery, true); // 蓝色查询按钮
            UIHelper.StyleButton(btnAdd, false);  // 白色新增按钮
            UIHelper.StyleButton(btnEdit, false); // 白色修改按钮
            LoadData();
        }

        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();

            var list = _productService.GetAllProducts(keyword);

            dgvProducts.DataSource = list;

            dgvProducts.Columns["ProductId"].Visible = false;

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 传入 0 表示新增
            FrmProductEdit frm = new FrmProductEdit(0);

            // 如果保存成功（DialogResult == OK），刷新列表
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 检查用户有没有选中一行
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要修改的商品！");
                return;
            }

            // 获取选中行的 ProductId (假设第一列是实体对象或者你绑定了Id)
            // 技巧：直接从绑定的对象里取值
            var selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as BaseProduct;

            if (selectedProduct != null)
            {
                FrmProductEdit frm = new FrmProductEdit(selectedProduct.ProductId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 文件|*.xlsx";
            sfd.FileName = "商品导入模版.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // 造一条示例数据
                var list = new List<Outdoor.BLL.ProductImportDto>
        {
            new Outdoor.BLL.ProductImportDto
            {
                ProductName = "示例商品-始祖鸟冲锋衣",
                Barcode = "999001",
                Category = "服装",
                Brand = "Arc'teryx",
                UnitPrice = 4500,
                CostPrice = 2800,
                Spec = "L码"
            }
        };

                // 生成 Excel
                MiniExcel.SaveAs(sfd.FileName, list);
                MessageBox.Show("模版已保存！");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel 文件|*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 调用 BLL 导入
                    string msg;
                    bool success = _productService.ImportProductsFromExcel(ofd.FileName, out msg);

                    if (success)
                    {
                        MessageBox.Show(msg);
                        LoadData(); // 刷新表格，立刻看到新数据
                    }
                    else
                    {
                        MessageBox.Show("导入失败：\n" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生异常：" + ex.Message);
                }
            }
        }
    }
}
