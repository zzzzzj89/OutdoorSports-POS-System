using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Outdoor.DAL.Models
{
    [Table("sys_logs")]
    public partial class SysLog
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("operation")]
        public string Operation { get; set; }

        [Column("details")]
        public string Details { get; set; }

        [Column("log_time")]
        public DateTime LogTime { get; set; }

    }
}
