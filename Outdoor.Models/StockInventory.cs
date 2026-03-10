using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 门店库存表
    /// </summary>
    public partial class StockInventory
    {
        public int InventoryId { get; set; }
        /// <summary>
        /// 门店ID
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 当前库存数量
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// 库存预警阈值
        /// </summary>
        public int? MinThreshold { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual BaseProduct Product { get; set; } = null!;
        public virtual SysStore Store { get; set; } = null!;
    }
}
