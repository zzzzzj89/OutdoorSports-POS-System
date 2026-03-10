namespace Outdoor.WinUI
{
    partial class FrmProductList
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
            btnImport = new Button();
            btnTemplate = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnQuery = new Button();
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnImport);
            panel1.Controls.Add(btnTemplate);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnQuery);
            panel1.Controls.Add(txtSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 103);
            panel1.TabIndex = 0;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(628, 46);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(155, 34);
            btnImport.TabIndex = 5;
            btnImport.Text = "导入商品数据";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnTemplate
            // 
            btnTemplate.Location = new Point(431, 46);
            btnTemplate.Name = "btnTemplate";
            btnTemplate.Size = new Size(162, 34);
            btnTemplate.TabIndex = 4;
            btnTemplate.Text = "下载导入模版";
            btnTemplate.UseVisualStyleBackColor = true;
            btnTemplate.Click += btnTemplate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(671, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "修改选定";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(553, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "新增商品";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(431, 6);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(112, 34);
            btnQuery.TabIndex = 1;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(382, 30);
            txtSearch.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 103);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.RowTemplate.Height = 32;
            dgvProducts.Size = new Size(800, 347);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // FrmProductList
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProducts);
            Controls.Add(panel1);
            Name = "FrmProductList";
            Text = "FrmProductList";
            WindowState = FormWindowState.Maximized;
            Load += FrmProductList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnQuery;
        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnImport;
        private Button btnTemplate;
    }
}