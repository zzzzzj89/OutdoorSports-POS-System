using System;
using System.Collections.Generic;

namespace Outdoor.DAL.Models
{
    /// <summary>
    /// 系统用户表
    /// </summary>
    public partial class SysUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        /// 加密密码
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; } = null!;
        /// <summary>
        /// 角色：超管/店长/收银员
        /// </summary>
        public string Role { get; set; } = null!;
        /// <summary>
        /// 所属门店ID
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 状态：1启用 0禁用
        /// </summary>
        public sbyte? Status { get; set; }

        public virtual SysStore Store { get; set; } = null!;
    }
}
