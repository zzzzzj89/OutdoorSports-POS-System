using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.DAL.Models
{
    [Table("sys_promotions")] // 对应数据库表名
    public partial class SysPromotion
    {
        [Key]
        [Column("promo_id")]
        public int PromoId { get; set; }

        [Column("promo_name")]
        public string PromoName { get; set; }



        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("discount_rate")]
        public decimal DiscountRate { get; set; }

        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Column("end_time")]
        public DateTime EndTime { get; set; }

        [Column("is_active")]
        public sbyte? IsActive { get; set; } // MySQL 的 TINYINT 通常映射为 sbyte 或 bool

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        // --- 导航属性 (关联商品) ---
        [ForeignKey("ProductId")]
        public virtual BaseProduct Product { get; set; }
    }
}
