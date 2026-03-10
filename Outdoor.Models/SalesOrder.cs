using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 销售订单主表
    /// </summary>
    public partial class SalesOrder
    {
        public SalesOrder()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int OrderId { get; set; }
        /// <summary>
        /// 订单编号(按时间生成)
        /// </summary>
        public string OrderNo { get; set; } = null!;
        /// <summary>
        /// 发生交易的门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 会员ID(可为空，散客)
        /// </summary>
        public int? MemberId { get; set; }
        /// <summary>
        /// 订单总额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal ActualAmount { get; set; }
        /// <summary>
        /// 支付方式(微信/支付宝/现金)
        /// </summary>
        public string? PaymentMethod { get; set; }
        public DateTime? OrderTime { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public int? OperatorId { get; set; }
        public int? Status { get; set; }

        public virtual SysStore Store { get; set; } = null!;
        public virtual VipMember Member { get; set; } = null!;
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
