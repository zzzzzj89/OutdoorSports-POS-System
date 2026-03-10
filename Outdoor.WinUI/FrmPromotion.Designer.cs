namespace Outdoor.WinUI
{
    partial class FrmPromotion
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
            groupBox1 = new GroupBox();
            btnAdd = new Button();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            txtRate = new TextBox();
            txtName = new TextBox();
            cmbProducts = new ComboBox();
            dgvPromos = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(dtpEnd);
            groupBox1.Controls.Add(dtpStart);
            groupBox1.Controls.Add(txtRate);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(cmbProducts);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(72, 263);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "保存";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(12, 176);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(300, 30);
            dtpEnd.TabIndex = 4;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(12, 123);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(300, 30);
            dtpStart.TabIndex = 3;
            // 
            // txtRate
            // 
            txtRate.Location = new Point(217, 65);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(128, 30);
            txtRate.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(217, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(128, 30);
            txtName.TabIndex = 1;
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(12, 29);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(182, 32);
            cmbProducts.TabIndex = 0;
            // 
            // dgvPromos
            // 
            dgvPromos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromos.Dock = DockStyle.Fill;
            dgvPromos.Location = new Point(387, 0);
            dgvPromos.Name = "dgvPromos";
            dgvPromos.RowHeadersWidth = 62;
            dgvPromos.RowTemplate.Height = 32;
            dgvPromos.Size = new Size(413, 450);
            dgvPromos.TabIndex = 1;
            // 
            // FrmPromotion
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPromos);
            Controls.Add(groupBox1);
            Name = "FrmPromotion";
            Text = "FrmPromotion";
            Load += FrmPromotion_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbProducts;
        private DataGridView dgvPromos;
        private Button btnAdd;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private TextBox txtRate;
        private TextBox txtName;
    }
}