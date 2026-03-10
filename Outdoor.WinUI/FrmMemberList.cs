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
    public partial class FrmMemberList : Form
    {
        private MemberService _memberService = new MemberService();
        public FrmMemberList()
        {
            InitializeComponent();
            // 自动生成列
            dgvMembers.AutoGenerateColumns = true;

            // 美化 (如果有 UIHelper)
            UIHelper.StyleDataGridView(dgvMembers);
        }

        private void FrmMemberList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            var list = _memberService.GetMemberList(keyword);

            dgvMembers.DataSource = list;

            // 隐藏不想显示的列 (比如 StoreId, Password 等如果有的话)
            if (dgvMembers.Columns["Store"] != null) dgvMembers.Columns["Store"].Visible = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmMemberEdit frm = new FrmMemberEdit(0); // 0 = 新增
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // 刷新列表
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一个会员！");
                return;
            }
            // 获取选中行的对象
            var member = dgvMembers.SelectedRows[0].DataBoundItem as VipMember;
            if (member != null)
            {
                FrmMemberEdit frm = new FrmMemberEdit(member.MemberId); // 传入ID = 修改
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;

            var member = dgvMembers.SelectedRows[0].DataBoundItem as VipMember;

            if (MessageBox.Show($"确定要删除会员【{member.MemberName}】吗？\n删除后不可恢复！",
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _memberService.DeleteMember(member.MemberId);
                LoadData();
                MessageBox.Show("删除成功。");
            }
        }
    }
}
