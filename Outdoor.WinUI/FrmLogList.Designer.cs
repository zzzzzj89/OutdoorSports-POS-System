namespace Outdoor.WinUI
{
    partial class FrmLogList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvLogs = new DataGridView();
            btnClose = new Button();
            panel1 = new Panel();
            btnQuery = new Button();
            txtKeyword = new TextBox();
            label3 = new Label();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLogs
            // 
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Dock = DockStyle.Bottom;
            dgvLogs.Location = new Point(0, 194);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.RowHeadersWidth = 62;
            dgvLogs.RowTemplate.Height = 32;
            dgvLogs.Size = new Size(800, 256);
            dgvLogs.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(676, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "退出";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnQuery);
            panel1.Controls.Add(txtKeyword);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 194);
            panel1.TabIndex = 2;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(349, 106);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(112, 34);
            btnQuery.TabIndex = 6;
            btnQuery.Text = "查询日志";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(129, 108);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(150, 30);
            txtKeyword.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 4;
            label3.Text = "关键词";
            label3.Click += label3_Click;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(129, 53);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(300, 30);
            dtpEnd.TabIndex = 3;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(129, 4);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(300, 30);
            dtpStart.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 58);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 1;
            label2.Text = "结束时间";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 0;
            label1.Text = "起始时间";
            // 
            // FrmLogList
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(dgvLogs);
            Name = "FrmLogList";
            Text = "FrmLogList";
            Load += FrmLogList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLogs;
        private Button btnClose;
        private Panel panel1;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button btnQuery;
        private TextBox txtKeyword;
    }
}