using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 门店基础信息表
    /// </summary>
    public partial class SysStore
    {
        public SysStore()
        {
            SalesOrders = new HashSet<SalesOrder>();
            StockInventories = new HashSet<StockInventory>();
            SysUsers = new HashSet<SysUser>();
        }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; } = null!;
        /// <summary>
        /// 类型：总部/分店
        /// </summary>
        public string? StoreType { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string? Phone { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        public virtual ICollection<StockInventory> StockInventories { get; set; }
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
