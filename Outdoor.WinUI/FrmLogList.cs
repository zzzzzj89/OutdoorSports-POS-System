using Outdoor.BLL;
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
    public partial class FrmLogList : Form
    {
        private LogService _logService = new LogService();
        public FrmLogList()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogList_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpEnd.Value = DateTime.Now;

            // 自动查一次
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logService.SearchLogs(dtpStart.Value, dtpEnd.Value, txtKeyword.Text.Trim());
                dgvLogs.DataSource = list;

                // 隐藏一些不必要的列 (比如 ID)
                if (dgvLogs.Columns["LogId"] != null) dgvLogs.Columns["LogId"].Visible = false;
                if (dgvLogs.Columns["UserId"] != null) dgvLogs.Columns["UserId"].Visible = false;

                // 调整列宽
                if (dgvLogs.Columns["LogTime"] != null)
                {
                    dgvLogs.Columns["LogTime"].HeaderText = "操作时间";
                    dgvLogs.Columns["LogTime"].Width = 150;
                    dgvLogs.Columns["LogTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                if (dgvLogs.Columns["Operation"] != null) dgvLogs.Columns["Operation"].Width = 100;
                if (dgvLogs.Columns["Details"] != null) dgvLogs.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // 详情列自动填满
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败：" + ex.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
