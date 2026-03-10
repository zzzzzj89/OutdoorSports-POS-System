namespace Outdoor.WinUI
{
    partial class FrmStockIn
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
            txtSearch = new TextBox();
            btnQuery = new Button();
            dgvPrducts = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            lblCurrentStock = new Label();
            lblProductName = new Label();
            btnConfirm = new Button();
            numQuantity = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrducts).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(11, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(242, 30);
            txtSearch.TabIndex = 0;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(259, 29);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(112, 34);
            btnQuery.TabIndex = 1;
            btnQuery.Text = "查找商品";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // dgvPrducts
            // 
            dgvPrducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrducts.Location = new Point(11, 65);
            dgvPrducts.Name = "dgvPrducts";
            dgvPrducts.RowHeadersWidth = 62;
            dgvPrducts.RowTemplate.Height = 32;
            dgvPrducts.Size = new Size(360, 372);
            dgvPrducts.TabIndex = 2;
            dgvPrducts.CellClick += dgvPrducts_CellClick;
            dgvPrducts.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(dgvPrducts);
            groupBox1.Controls.Add(btnQuery);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 450);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblCurrentStock);
            groupBox2.Controls.Add(lblProductName);
            groupBox2.Controls.Add(btnConfirm);
            groupBox2.Controls.Add(numQuantity);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Dock = DockStyle.Right;
            groupBox2.Location = new Point(386, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(414, 450);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.Location = new Point(148, 131);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(0, 24);
            lblCurrentStock.TabIndex = 6;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(148, 65);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(0, 24);
            lblProductName.TabIndex = 5;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(124, 338);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(140, 56);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "确认入库";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(148, 202);
            numQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(180, 30);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 204);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 2;
            label3.Text = "入库数量：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 131);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 1;
            label2.Text = "当前库存：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 65);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 0;
            label1.Text = "选中商品：";
            // 
            // FrmStockIn
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmStockIn";
            Text = "FrmStockIn";
            Load += FrmStockIn_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrducts).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtSearch;
        private Button btnQuery;
        private DataGridView dgvPrducts;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnConfirm;
        private NumericUpDown numQuantity;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblCurrentStock;
        private Label lblProductName;
    }
}