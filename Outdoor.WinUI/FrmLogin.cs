using Outdoor.BLL;
using Outdoor.Models;
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
    public partial class FrmLogin : Form
    {

        // 实例化业务逻辑类
        private UserService _userService = new UserService();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            string msg = "";

            // 调用 BLL 层的方法
            bool isSuccess = _userService.Login(user, pwd, out msg);

            if (isSuccess)
            {
                MessageBox.Show($"登录成功！\n欢迎回来，{GlobalContext.CurrentUser.RealName}\n当前门店：{GlobalContext.CurrentStore?.StoreName}", "提示");

                // 登录成功后，应该跳转到主界面
                // 这里我们暂时先把 DialogResult 设为 OK，关闭登录窗
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(msg, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
