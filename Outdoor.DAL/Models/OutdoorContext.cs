using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Outdoor.DAL.Models
{
    public partial class OutdoorContext : DbContext
    {
        public OutdoorContext()
        {
        }

        public OutdoorContext(DbContextOptions<OutdoorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseProduct> BaseProducts { get; set; } = null!;
        public virtual DbSet<SalesOrder> SalesOrders { get; set; } = null!;
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; } = null!;
        public virtual DbSet<StockInventory> StockInventories { get; set; } = null!;
        public virtual DbSet<SysStore> SysStores { get; set; } = null!;
        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;
        public virtual DbSet<VipMember> VipMembers { get; set; } = null!;

        public virtual DbSet<SysLog> SysLogs { get; set; } = null!;

        public virtual DbSet<SysPromotion> SysPromotions { get; set; }

        public int? Status { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning        To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=outdoor_chain_db;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<BaseProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.ToTable("base_products");

                entity.HasComment("商品基础资料表");

                entity.HasIndex(e => e.Barcode, "barcode")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("商品ID");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .HasColumnName("barcode")
                    .HasComment("条形码(扫码用)");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .HasColumnName("brand")
                    .HasComment("品牌");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category")
                    .HasComment("分类(如：登山鞋/冲锋衣)");

                entity.Property(e => e.CostPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("cost_price")
                    .HasComment("成本价");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("商品描述");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("product_name")
                    .HasComment("商品名称");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .HasColumnName("spec")
                    .HasComment("规格/尺码");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("unit_price")
                    .HasComment("统一零售价");
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.ToTable("sales_orders");

                entity.HasComment("销售订单主表");

                entity.HasIndex(e => e.OrderNo, "order_no")
                    .IsUnique();

                entity.HasIndex(e => e.StoreId, "store_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ActualAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("actual_amount")
                    .HasComment("实收金额");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasComment("会员ID(可为空，散客)");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作员ID");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .HasColumnName("order_no")
                    .HasComment("订单编号(按时间生成)");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasColumnName("order_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(20)
                    .HasColumnName("payment_method")
                    .HasComment("支付方式(微信/支付宝/现金)");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasComment("发生交易的门店");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_amount")
                    .HasComment("订单总额");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_orders_ibfk_1");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PRIMARY");

                entity.ToTable("sales_order_details");

                entity.HasComment("订单明细表");

                entity.HasIndex(e => e.OrderId, "order_id");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.Property(e => e.DetailId).HasColumnName("detail_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasComment("购买数量");

                entity.Property(e => e.SalePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("sale_price")
                    .HasComment("销售单价");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(10, 2)
                    .HasColumnName("subtotal")
                    .HasComment("小计金额");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_order_details_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_order_details_ibfk_2");
            });

            modelBuilder.Entity<StockInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("PRIMARY");

                entity.ToTable("stock_inventory");

                entity.HasComment("门店库存表");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.HasIndex(e => new { e.StoreId, e.ProductId }, "uk_store_product")
                    .IsUnique();

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.MinThreshold)
                    .HasColumnName("min_threshold")
                    .HasDefaultValueSql("'5'")
                    .HasComment("库存预警阈值");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("商品ID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'0'")
                    .HasComment("当前库存数量");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasComment("门店ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StockInventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stock_inventory_ibfk_2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StockInventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stock_inventory_ibfk_1");
            });

            modelBuilder.Entity<SysStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_stores");

                entity.HasComment("门店基础信息表");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasComment("门店ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address")
                    .HasComment("地址");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .HasComment("联系电话");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(100)
                    .HasColumnName("store_name")
                    .HasComment("门店名称");

                entity.Property(e => e.StoreType)
                    .HasColumnType("enum('Headquarters','Branch')")
                    .HasColumnName("store_type")
                    .HasDefaultValueSql("'Branch'")
                    .HasComment("类型：总部/分店");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_users");

                entity.HasComment("系统用户表");

                entity.HasIndex(e => e.StoreId, "store_id");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("用户ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password")
                    .HasComment("加密密码");

                entity.Property(e => e.RealName)
                    .HasMaxLength(50)
                    .HasColumnName("real_name")
                    .HasComment("真实姓名");

                entity.Property(e => e.Role)
                    .HasColumnType("enum('Admin','Manager','Cashier')")
                    .HasColumnName("role")
                    .HasComment("角色：超管/店长/收银员");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态：1启用 0禁用");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasComment("所属门店ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username")
                    .HasComment("登录账号");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.SysUsers)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sys_users_ibfk_1");
            });

            modelBuilder.Entity<VipMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PRIMARY");

                entity.ToTable("vip_members");

                entity.HasComment("会员档案表");

                entity.HasIndex(e => e.CardNumber, "card_number")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "phone")
                    .IsUnique();

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.Balance)
                    .HasPrecision(10, 2)
                    .HasColumnName("balance")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("储值余额");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .HasColumnName("card_number")
                    .HasComment("会员卡号");

                entity.Property(e => e.Level)
                    .HasMaxLength(20)
                    .HasColumnName("level")
                    .HasDefaultValueSql("'普通会员'")
                    .HasComment("会员等级");

                entity.Property(e => e.MemberName)
                    .HasMaxLength(50)
                    .HasColumnName("member_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasDefaultValueSql("'0'")
                    .HasComment("当前积分");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("register_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
