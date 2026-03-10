namespace Outdoor.WinUI
{
    partial class FrmProductEdit
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
            btnSave = new Button();
            txtPrice = new TextBox();
            txtCategory = new TextBox();
            txtBarcode = new TextBox();
            txtName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(97, 330);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 43);
            btnSave.TabIndex = 17;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(213, 237);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 30);
            txtPrice.TabIndex = 16;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(213, 176);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(150, 30);
            txtCategory.TabIndex = 15;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(213, 115);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(150, 30);
            txtBarcode.TabIndex = 14;
            // 
            // txtName
            // 
            txtName.Location = new Point(213, 54);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 30);
            txtName.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(97, 243);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 12;
            label4.Text = "零售价：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 182);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 11;
            label3.Text = "分类：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 121);
            label2.Name = "label2";
            label2.Size = new Size(87, 24);
            label2.TabIndex = 10;
            label2.Text = "条形码 ：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 60);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 9;
            label1.Text = "商品名称：";
            // 
            // FrmProductEdit
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtPrice);
            Controls.Add(txtCategory);
            Controls.Add(txtBarcode);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmProductEdit";
            Text = "FrmProductEdit";
            Load += FrmProductEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtPrice;
        private TextBox txtCategory;
        private TextBox txtBarcode;
        private TextBox txtName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}