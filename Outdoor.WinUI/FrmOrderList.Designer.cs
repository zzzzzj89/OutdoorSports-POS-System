namespace Outdoor.WinUI
{
    partial class FrmOrderList
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
            lblOrderNo = new Label();
            btnRefund = new Button();
            btnSearch = new Button();
            txtOrderNo = new TextBox();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            dgvOrders = new DataGridView();
            dgvDetails = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblOrderNo);
            panel1.Controls.Add(btnRefund);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtOrderNo);
            panel1.Controls.Add(dtpEnd);
            panel1.Controls.Add(dtpStart);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 117);
            panel1.TabIndex = 0;
            // 
            // lblOrderNo
            // 
            lblOrderNo.AutoSize = true;
            lblOrderNo.Location = new Point(96, 44);
            lblOrderNo.Name = "lblOrderNo";
            lblOrderNo.Size = new Size(82, 24);
            lblOrderNo.TabIndex = 5;
            lblOrderNo.Text = "订单号：";
            // 
            // btnRefund
            // 
            btnRefund.Location = new Point(543, 40);
            btnRefund.Name = "btnRefund";
            btnRefund.Size = new Size(112, 34);
            btnRefund.TabIndex = 4;
            btnRefund.Text = "退货";
            btnRefund.UseVisualStyleBackColor = true;
            btnRefund.Click += btnRefund_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(396, 39);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtOrderNo
            // 
            txtOrderNo.Location = new Point(199, 44);
            txtOrderNo.Name = "txtOrderNo";
            txtOrderNo.Size = new Size(150, 30);
            txtOrderNo.TabIndex = 2;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(497, 3);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(300, 30);
            dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(98, 3);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(300, 30);
            dtpStart.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(0, 117);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.Size = new Size(800, 333);
            dgvOrders.TabIndex = 1;
            dgvOrders.CellContentClick += dgvOrders_CellContentClick;
            // 
            // dgvDetails
            // 
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Dock = DockStyle.Bottom;
            dgvDetails.Location = new Point(0, 271);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RowHeadersWidth = 62;
            dgvDetails.RowTemplate.Height = 32;
            dgvDetails.Size = new Size(800, 179);
            dgvDetails.TabIndex = 2;
            // 
            // FrmOrderList
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDetails);
            Controls.Add(dgvOrders);
            Controls.Add(panel1);
            Name = "FrmOrderList";
            Text = "FrmOrderList";
            Load += FrmOrderList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label lblOrderNo;
        private Button btnRefund;
        private Button btnSearch;
        private TextBox txtOrderNo;
        private DataGridView dgvOrders;
        private DataGridView dgvDetails;
    }
}