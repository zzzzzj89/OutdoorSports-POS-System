using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 订单明细表
    /// </summary>
    public partial class SalesOrderDetail
    {
        public int DetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 小计金额
        /// </summary>
        public decimal Subtotal { get; set; }

        public virtual SalesOrder Order { get; set; } = null!;
        public virtual BaseProduct Product { get; set; } = null!;
    }
}
