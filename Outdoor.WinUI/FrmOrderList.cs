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
    public partial class FrmOrderList : Form
    {
        private OrderService _orderService = new OrderService();

        public FrmOrderList()
        {
            InitializeComponent();
        }

        private void FrmOrderList_Load(object sender, EventArgs e)
        {
            // 默认查询最近 7 天
            dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpEnd.Value = DateTime.Now;
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = _orderService.SearchOrders(dtpStart.Value, dtpEnd.Value, txtOrderNo.Text.Trim());
            dgvOrders.DataSource = list;

            // 隐藏一些不需要显示的列 (比如外键对象)
            if (dgvOrders.Columns["Store"] != null) dgvOrders.Columns["Store"].Visible = false;
            if (dgvOrders.Columns["Member"] != null) dgvOrders.Columns["Member"].Visible = false;
            // 如果你想显示“正常/退货”文字而不是数字，可以用 CellFormatting 事件，或者简单点先看数字
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var order = dgvOrders.Rows[e.RowIndex].DataBoundItem as SalesOrder;
            if (order != null)
            {
                var details = _orderService.GetDetails(order.OrderId);
                dgvDetails.DataSource = details;

                // 同样隐藏外键列
                if (dgvDetails.Columns["Order"] != null) dgvDetails.Columns["Order"].Visible = false;
                if (dgvDetails.Columns["Product"] != null) dgvDetails.Columns["Product"].Visible = false;
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要退货的订单！");
                return;
            }

            var order = dgvOrders.SelectedRows[0].DataBoundItem as SalesOrder;

            if (order.Status == 2)
            {
                MessageBox.Show("该订单已退货，无需重复操作。");
                return;
            }

            if (MessageBox.Show($"确定要对订单 {order.OrderNo} 进行退货处理吗？\n\n注意：退货后库存将自动加回。",
                "退货确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string msg;
                bool success = _orderService.Refund(order.OrderId, out msg);
                if (success)
                {
                    MessageBox.Show("退货成功！库存已恢复。");
                    btnSearch_Click(null, null); // 刷新列表
                    dgvDetails.DataSource = null; // 清空明细
                }
                else
                {
                    MessageBox.Show("退货失败：" + msg);
                }
            }
        }
    }
}
