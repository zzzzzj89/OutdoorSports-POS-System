using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 商品基础资料表
    /// </summary>
    public partial class BaseProduct
    {
        public BaseProduct()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
            StockInventories = new HashSet<StockInventory>();
        }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 条形码(扫码用)
        /// </summary>
        public string Barcode { get; set; } = null!;
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; } = null!;
        /// <summary>
        /// 分类(如：登山鞋/冲锋衣)
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string? Brand { get; set; }
        /// <summary>
        /// 统一零售价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal? CostPrice { get; set; }
        /// <summary>
        /// 规格/尺码
        /// </summary>
        public string? Spec { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string? Description { get; set; }

        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual ICollection<StockInventory> StockInventories { get; set; }
    }
}
