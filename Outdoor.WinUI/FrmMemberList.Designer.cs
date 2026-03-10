namespace Outdoor.WinUI
{
    partial class FrmMemberList
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
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnQuery = new Button();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvMembers = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnQuery);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 114);
            panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(604, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(142, 39);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "注册";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(348, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(181, 60);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "修改";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(17, 60);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(112, 34);
            btnQuery.TabIndex = 2;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(203, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(179, 30);
            txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 8);
            label1.Name = "label1";
            label1.Size = new Size(180, 24);
            label1.TabIndex = 0;
            label1.Text = "请输入手机号/姓名：";
            // 
            // dgvMembers
            // 
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Dock = DockStyle.Fill;
            dgvMembers.Location = new Point(0, 114);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersWidth = 62;
            dgvMembers.RowTemplate.Height = 32;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.Size = new Size(800, 336);
            dgvMembers.TabIndex = 1;
            // 
            // FrmMemberList
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvMembers);
            Controls.Add(panel1);
            Name = "FrmMemberList";
            Text = "FrmMemberList";
            Load += FrmMemberList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnQuery;
        private TextBox txtSearch;
        private Label label1;
        private DataGridView dgvMembers;
    }
}