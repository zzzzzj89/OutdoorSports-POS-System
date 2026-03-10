namespace Outdoor.WinUI
{
    partial class FrmMemberEdit
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
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            cmbLevel = new ComboBox();
            label4 = new Label();
            txtPoints = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 63);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 0;
            label1.Text = "姓名：";
            label1.Click += label1_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(185, 63);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 30);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 125);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 2;
            label2.Text = "手机号：";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(185, 125);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 30);
            txtPhone.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 189);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 4;
            label3.Text = "会员等级：";
            // 
            // cmbLevel
            // 
            cmbLevel.FormattingEnabled = true;
            cmbLevel.Items.AddRange(new object[] { "普通会员", "黄金会员", "钻石会员" });
            cmbLevel.Location = new Point(185, 186);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(150, 32);
            cmbLevel.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 241);
            label4.Name = "label4";
            label4.Size = new Size(100, 24);
            label4.TabIndex = 6;
            label4.Text = "当前积分：";
            // 
            // txtPoints
            // 
            txtPoints.Location = new Point(185, 238);
            txtPoints.Name = "txtPoints";
            txtPoints.ReadOnly = true;
            txtPoints.Size = new Size(150, 30);
            txtPoints.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(112, 309);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(162, 55);
            btnSave.TabIndex = 8;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmMemberEdit
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 446);
            Controls.Add(btnSave);
            Controls.Add(txtPoints);
            Controls.Add(label4);
            Controls.Add(cmbLevel);
            Controls.Add(label3);
            Controls.Add(txtPhone);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "FrmMemberEdit";
            Text = "FrmMemberEdit";
            Load += FrmMemberEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtPhone;
        private Label label3;
        private ComboBox cmbLevel;
        private Label label4;
        private TextBox txtPoints;
        private Button btnSave;
    }
}