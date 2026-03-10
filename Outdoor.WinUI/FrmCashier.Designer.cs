namespace Outdoor.WinUI
{
    partial class FrmCashier
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
            panel1 = new Panel();
            label1 = new Label();
            txtBarcode = new TextBox();
            panel2 = new Panel();
            btnSettle = new Button();
            lblTotal = new Label();
            dgvCart = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBarcode);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 82);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 33);
            label1.Name = "label1";
            label1.Size = new Size(154, 24);
            label1.TabIndex = 1;
            label1.Text = "请扫描商品条码：";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(182, 30);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(202, 30);
            txtBarcode.TabIndex = 0;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSettle);
            panel2.Controls.Add(lblTotal);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 344);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 106);
            panel2.TabIndex = 1;
            // 
            // btnSettle
            // 
            btnSettle.Location = new Point(168, 43);
            btnSettle.Name = "btnSettle";
            btnSettle.Size = new Size(112, 34);
            btnSettle.TabIndex = 1;
            btnSettle.Text = "结算收款";
            btnSettle.UseVisualStyleBackColor = true;
            btnSettle.Click += btnSettle_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.IndianRed;
            lblTotal.Location = new Point(77, 48);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 24);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "￥0.00";
            // 
            // dgvCart
            // 
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 82);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 62;
            dgvCart.RowTemplate.Height = 32;
            dgvCart.Size = new Size(800, 262);
            dgvCart.TabIndex = 2;
            // 
            // FrmCashier
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCart);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmCashier";
            Text = "FrmCashier";
            WindowState = FormWindowState.Maximized;
            Load += FrmCashier_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtBarcode;
        private Panel panel2;
        private DataGridView dgvCart;
        private Label label1;
        private Button btnSettle;
        private Label lblTotal;
    }
}