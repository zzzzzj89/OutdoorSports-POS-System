namespace Outdoor.WinUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. 先运行登录窗体
            FrmLogin loginForm = new FrmLogin();

            // ShowDialog 会阻塞代码，直到窗体关闭
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 2. 如果登录成功（返回了OK），才启动主窗体 (Form1)
                // 这里的 Form1 就是你未来的“系统主界面”，建议改名叫 FrmMain
                Application.Run(new FrmMain());
            }
            else
            {
                // 如果直接关掉登录窗，程序就结束
                Application.Exit();
            }
        }
    }
}