using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.WinUI
{
    public class UIHelper
    {
        // 定义主题颜色
        public static Color PrimaryColor = Color.FromArgb(24, 144, 255); // 科技蓝
        public static Color TextColor = Color.FromArgb(48, 49, 51);      // 深灰字体
        public static Color BgColor = Color.FromArgb(240, 242, 245);     // 浅灰背景

        // 1. 美化 DataGridView (表格)
        public static void StyleDataGridView(DataGridView dgv)
        {
            // 基础设置
            dgv.BackgroundColor = Color.White; // 表格背景全白
            dgv.BorderStyle = BorderStyle.None; // 去掉边框
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // 只显示横线
            dgv.EnableHeadersVisualStyles = false; // 允许自定义表头样式
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 选中整行
            dgv.MultiSelect = false; // 禁止多选
            dgv.RowHeadersVisible = false; // 隐藏最左侧那一条空白列

            // 表头样式
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250); // 浅灰表头
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40; // 表头加高

            // 行样式
            dgv.DefaultCellStyle.Font = new Font("微软雅黑", 9);
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 247, 255); // 选中时变成浅蓝，而不是深蓝
            dgv.DefaultCellStyle.SelectionForeColor = TextColor; // 选中时文字不白，保持深灰
            dgv.RowTemplate.Height = 35; // 行高增加，不拥挤

            // 交替行颜色
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
        }

        // 2. 美化按钮 (扁平化)
        public static void StyleButton(Button btn, bool isPrimary = true)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; // 去掉边框
            btn.Cursor = Cursors.Hand; // 鼠标变成手型
            btn.Font = new Font("微软雅黑", 10, FontStyle.Regular);

            if (isPrimary)
            {
                // 主按钮（蓝色）
                btn.BackColor = PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 169, 255); // 悬停变亮
            }
            else
            {
                // 次要按钮（灰色/白色）
                btn.BackColor = Color.White;
                btn.ForeColor = TextColor;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(220, 223, 230);
            }
        }

        // 3. 美化窗体背景
        public static void StyleForm(Form form)
        {
            form.BackColor = BgColor;
            form.Font = new Font("微软雅黑", 9);
            form.StartPosition = FormStartPosition.CenterScreen;
        }


    }


}
