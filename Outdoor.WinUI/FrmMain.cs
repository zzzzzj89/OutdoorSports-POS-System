using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Outdoor.Models;
using Outdoor.BLL;
using System.Drawing.Text;
using Microsoft.VisualBasic.ApplicationServices;
using Outdoor.DAL;
using Outdoor.DAL.Models;

namespace Outdoor.WinUI
{
    public partial class FrmMain : Form
    {
        private ReportService _reportService = new ReportService();
        private LogService _logService = new LogService();
        public FrmMain()
        {
            InitializeComponent();
        }

        // 动态加载图表的方法
        private void LoadDashboardData()
        {
            // 确保已经登录，有门店信息
            if (GlobalContext.CurrentStore == null) return;
            int storeId = GlobalContext.CurrentStore.StoreId;

            // --- 加载图表 ---
            // 调用 BLL 获取数据
            var topProducts = _reportService.GetTopProducts(storeId);

            // 动态创建图表放入 pnlChartContainer
            CreateChart(topProducts);

            // --- 加载 KPI 数字 (可选，假设你有这些Label) ---
            // decimal sales = _reportService.GetTodaySales(storeId);
            // lblSales.Text = sales.ToString("C2");
        }

        // 这是一个辅助方法，专门用来画图
        private void CreateChart(System.Collections.Generic.List<Outdoor.DAL.TopProductDto> data)
        {
            // 检查 Panel 里面是否已经有图表了
            Chart chart;
            if (pnlChartContainer.Controls.Count > 0 && pnlChartContainer.Controls[0] is Chart)
            {
                chart = (Chart)pnlChartContainer.Controls[0];
            }
            else
            {
                // 动态创建图表控件
                chart = new Chart();
                chart.Dock = DockStyle.Fill;
                chart.Parent = pnlChartContainer; // 放入面板

                ChartArea area = new ChartArea("MainArea");
                chart.ChartAreas.Add(area);

                Series series = new Series("Sales");
                series.ChartType = SeriesChartType.Column; // 柱状图
                series.IsValueShownAsLabel = true;
                chart.Series.Add(series);

                chart.Titles.Add("热销商品 TOP 5");
            }

            // 绑定数据
            chart.Series[0].Points.Clear();
            foreach (var item in data)
            {
                chart.Series[0].Points.AddXY(item.ProductName, item.TotalQuantity);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (GlobalContext.CurrentUser != null)
            {
                lblCurrentUser.Text = $"当前用户：{GlobalContext.CurrentUser.RealName}" +
                    $"({GlobalContext.CurrentUser.Role})";
            }

            if (GlobalContext.CurrentUser != null)
            {
                lblCurrentStore.Text = $"  |  所属门店：{GlobalContext.CurrentStore.StoreName}";
            }


            LoadDashboardData();




        }

        private void ApplyPermissions()
        {
            // 获取当前用户的角色
            string role = GlobalContext.CurrentUser.Role; // 假设数据库存的是 "Admin", "Manager", "Cashier"

            // 默认先全部显示
            tsmiProduct.Visible = true; // 商品管理
            tsmiStock.Visible = true;   // 库存管理
            tsmiSale.Visible = true;    // 销售收银
            tsmiMember.Visible = true;  // 会员管理
            tsmiSystem.Visible = true;  // 系统管理

            // 根据角色隐藏
            if (role == "Cashier") // 收银员
            {
                tsmiProduct.Visible = false; // 不能改商品
                tsmiStock.Visible = false;   // 不能入库
                tsmiMember.Visible = false;  // 不能看会员
                tsmiSystem.Visible = false;  // 不能看系统设置
                                             // 只能看 tsmiSale (收银) 和 会员
            }
            else if (role == "Manager") // 店长
            {
                tsmiSystem.Visible = false; // 店长不能改系统配置（如备份数据库）
            }
        }

        private void 商品资料维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductList frm = new FrmProductList();
            frm.ShowDialog();
        }

        private void 销售收银ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashier frm = new FrmCashier();
            frm.ShowDialog();
        }

        private void 商品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStockIn frm = new FrmStockIn();
            frm.ShowDialog();
        }

        private void 历史订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrderList frm = new FrmOrderList();
            frm.ShowDialog();
        }

        private void 会员资料维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMemberList frm = new FrmMemberList();
            frm.ShowDialog();
        }

        private void 促销管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPromotion frm = new FrmPromotion();
            frm.ShowDialog();
        }

        private void tsmiLogList_Click(object sender, EventArgs e)
        {
            if (GlobalContext.CurrentUser.Role == "Cashier")
            {
                MessageBox.Show("权限不足！收银员无法查看日志。");
                return;
            }

            FrmLogList frm = new FrmLogList();
            frm.ShowDialog();
        }
    }
}
