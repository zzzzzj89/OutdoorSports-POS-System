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
    public partial class FrmMemberEdit : Form
    {

        private MemberService _memberService = new MemberService();
        private int _memberId = 0; // 0表示新增，>0表示修改
        public FrmMemberEdit(int id = 0)
        {
            InitializeComponent();
            _memberId = id;

            // 默认选中第一个等级
            cmbLevel.SelectedIndex = 0;

            // 如果你有 UIHelper，可以在这里美化
            UIHelper.StyleButton(btnSave);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMemberEdit_Load(object sender, EventArgs e)
        {
            if (_memberId > 0)
            {
                this.Text = "修改会员";
                // 回显数据
                var m = _memberService.GetMemberById(_memberId);
                if (m != null)
                {
                    txtName.Text = m.MemberName;
                    txtPhone.Text = m.Phone;
                    cmbLevel.Text = m.Level;
                    txtPoints.Text = m.Points.ToString();
                }
            }
            else
            {
                this.Text = "注册新会员";
                txtPoints.Text = "0";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 简单的输入校验
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("姓名和手机号不能为空！");
                return;
            }

            // 2. 构建对象
            // 注意：修改时，我们通常只改界面上有的字段。
            // 但为了简单，我们 new 一个对象，让 EF Core 自己去处理 Update
            VipMember member = new VipMember
            {
                MemberId = _memberId,
                MemberName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                CardNumber = txtPhone.Text.Trim(), // 默认卡号=手机号
                Level = cmbLevel.Text,
                // 积分保持原样（如果是新增则是0，修改则读界面上的只读值）
                Points = int.Parse(txtPoints.Text)
            };

            // 3. 调用后台保存
            if (_memberService.SaveMember(member, out string msg))
            {
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK; // 关闭并返回成功信号
            }
            else
            {
                MessageBox.Show("保存失败：" + msg);
            }
        }
    }
}

