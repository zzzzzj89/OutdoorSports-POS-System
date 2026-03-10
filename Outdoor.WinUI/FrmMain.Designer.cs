namespace Outdoor.WinUI
{
    partial class FrmMain
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
            menuStrip1 = new MenuStrip();
            tsmiSystem = new ToolStripMenuItem();
            tsmiProduct = new ToolStripMenuItem();
            商品资料维护ToolStripMenuItem = new ToolStripMenuItem();
            促销管理ToolStripMenuItem = new ToolStripMenuItem();
            tsmiSale = new ToolStripMenuItem();
            历史订单ToolStripMenuItem = new ToolStripMenuItem();
            tsmiStock = new ToolStripMenuItem();
            商品入库ToolStripMenuItem = new ToolStripMenuItem();
            tsmiMember = new ToolStripMenuItem();
            会员资料维护ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblCurrentUser = new ToolStripStatusLabel();
            lblCurrentStore = new ToolStripStatusLabel();
            pnlChartContainer = new Panel();
            tsmiLogList = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiSystem, tsmiProduct, tsmiSale, tsmiStock, tsmiMember });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSystem
            // 
            tsmiSystem.DropDownItems.AddRange(new ToolStripItem[] { tsmiLogList });
            tsmiSystem.Name = "tsmiSystem";
            tsmiSystem.Size = new Size(98, 28);
            tsmiSystem.Text = "系统管理";
            // 
            // tsmiProduct
            // 
            tsmiProduct.DropDownItems.AddRange(new ToolStripItem[] { 商品资料维护ToolStripMenuItem, 促销管理ToolStripMenuItem });
            tsmiProduct.Name = "tsmiProduct";
            tsmiProduct.Size = new Size(98, 28);
            tsmiProduct.Text = "商品管理";
            // 
            // 商品资料维护ToolStripMenuItem
            // 
            商品资料维护ToolStripMenuItem.Name = "商品资料维护ToolStripMenuItem";
            商品资料维护ToolStripMenuItem.Size = new Size(270, 34);
            商品资料维护ToolStripMenuItem.Text = "商品资料维护";
            商品资料维护ToolStripMenuItem.Click += 商品资料维护ToolStripMenuItem_Click;
            // 
            // 促销管理ToolStripMenuItem
            // 
            促销管理ToolStripMenuItem.Name = "促销管理ToolStripMenuItem";
            促销管理ToolStripMenuItem.Size = new Size(270, 34);
            促销管理ToolStripMenuItem.Text = "促销管理";
            促销管理ToolStripMenuItem.Click += 促销管理ToolStripMenuItem_Click;
            // 
            // tsmiSale
            // 
            tsmiSale.DropDownItems.AddRange(new ToolStripItem[] { 历史订单ToolStripMenuItem });
            tsmiSale.Name = "tsmiSale";
            tsmiSale.Size = new Size(98, 28);
            tsmiSale.Text = "销售收银";
            tsmiSale.Click += 销售收银ToolStripMenuItem_Click;
            // 
            // 历史订单ToolStripMenuItem
            // 
            历史订单ToolStripMenuItem.Name = "历史订单ToolStripMenuItem";
            历史订单ToolStripMenuItem.Size = new Size(182, 34);
            历史订单ToolStripMenuItem.Text = "历史订单";
            历史订单ToolStripMenuItem.Click += 历史订单ToolStripMenuItem_Click;
            // 
            // tsmiStock
            // 
            tsmiStock.DropDownItems.AddRange(new ToolStripItem[] { 商品入库ToolStripMenuItem });
            tsmiStock.Name = "tsmiStock";
            tsmiStock.Size = new Size(98, 28);
            tsmiStock.Text = "库存管理";
            // 
            // 商品入库ToolStripMenuItem
            // 
            商品入库ToolStripMenuItem.Name = "商品入库ToolStripMenuItem";
            商品入库ToolStripMenuItem.Size = new Size(182, 34);
            商品入库ToolStripMenuItem.Text = "商品入库";
            商品入库ToolStripMenuItem.Click += 商品入库ToolStripMenuItem_Click;
            // 
            // tsmiMember
            // 
            tsmiMember.DropDownItems.AddRange(new ToolStripItem[] { 会员资料维护ToolStripMenuItem });
            tsmiMember.Name = "tsmiMember";
            tsmiMember.Size = new Size(98, 28);
            tsmiMember.Text = "会员管理";
            // 
            // 会员资料维护ToolStripMenuItem
            // 
            会员资料维护ToolStripMenuItem.Name = "会员资料维护ToolStripMenuItem";
            会员资料维护ToolStripMenuItem.Size = new Size(218, 34);
            会员资料维护ToolStripMenuItem.Text = "会员资料维护";
            会员资料维护ToolStripMenuItem.Click += 会员资料维护ToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCurrentUser, lblCurrentStore });
            statusStrip1.Location = new Point(0, 419);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 31);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(124, 24);
            lblCurrentUser.Text = "当前用户：---";
            lblCurrentUser.Click += toolStripStatusLabel1_Click;
            // 
            // lblCurrentStore
            // 
            lblCurrentStore.Name = "lblCurrentStore";
            lblCurrentStore.Size = new Size(124, 24);
            lblCurrentStore.Text = "所属门店：---";
            // 
            // pnlChartContainer
            // 
            pnlChartContainer.Dock = DockStyle.Fill;
            pnlChartContainer.Location = new Point(0, 32);
            pnlChartContainer.Name = "pnlChartContainer";
            pnlChartContainer.Size = new Size(800, 387);
            pnlChartContainer.TabIndex = 2;
            // 
            // tsmiLogList
            // 
            tsmiLogList.Name = "tsmiLogList";
            tsmiLogList.Size = new Size(270, 34);
            tsmiLogList.Text = "日志查询";
            tsmiLogList.Click += tsmiLogList_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlChartContainer);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "户外运动连锁店销售管理系统 - [主界面]";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiSystem;
        private ToolStripMenuItem tsmiProduct;
        private ToolStripMenuItem 商品资料维护ToolStripMenuItem;
        private ToolStripMenuItem tsmiSale;
        private ToolStripMenuItem tsmiStock;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCurrentUser;
        private ToolStripStatusLabel lblCurrentStore;
        private Panel pnlChartContainer;
        private ToolStripMenuItem 商品入库ToolStripMenuItem;
        private ToolStripMenuItem 历史订单ToolStripMenuItem;
        private ToolStripMenuItem tsmiMember;
        private ToolStripMenuItem 会员资料维护ToolStripMenuItem;
        private ToolStripMenuItem 促销管理ToolStripMenuItem;
        private ToolStripMenuItem tsmiLogList;
    }
}