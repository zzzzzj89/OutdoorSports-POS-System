using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 会员档案表
    /// </summary>
    public partial class VipMember
    {
        public int MemberId { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string CardNumber { get; set; } = null!;
        public string MemberName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        /// <summary>
        /// 当前积分
        /// </summary>
        public int? Points { get; set; }
        /// <summary>
        /// 储值余额
        /// </summary>
        public decimal? Balance { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string? Level { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
