using Outdoor.DAL.Models;
using Outdoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.DAL
{
    public static class LogDAL
    {
        public static void AddLog(string operation, string details)
        {
            try
            {
                using (var context = new OutdoorContext())
                {
                    var log = new SysLog // 记得去 Scaffold 或手动建这个实体类
                    {
                        UserId = GlobalContext.CurrentUser.UserId,
                        UserName = GlobalContext.CurrentUser.RealName,
                        Operation = operation,
                        Details = details,
                        LogTime = DateTime.Now
                    };
                    context.SysLogs.Add(log);
                    context.SaveChanges();
                }
            }
            catch
            {
                // 日志记录失败不要影响主业务，吞掉异常
            }
        }


        public static void AddLog(string userName, string operation, string details)
        {
            try
            {
                using (var context = new OutdoorContext())
                {
                    var log = new SysLog // 记得去 Scaffold 或手动建这个实体类
                    {
                        UserId = GlobalContext.CurrentUser.UserId,
                        UserName = GlobalContext.CurrentUser.RealName,
                        Operation = operation,
                        Details = details,
                        LogTime = DateTime.Now
                    };
                    context.SysLogs.Add(log);
                    context.SaveChanges();
                }
            }
            catch
            {
                // 日志记录失败不要影响主业务，吞掉异常
            }
        }

        // [New!] 查询日志列表
        // 这里的 static 可能会导致上下文管理稍微麻烦一点，
        // 如果你之前把 AddLog 写成 static 了，这里也用 static 配合 using context 没问题。
        public static List<SysLog> GetLogs(DateTime start, DateTime end, string keyword = "")
        {
            using (var context = new OutdoorContext())
            {
                var query = context.SysLogs.AsQueryable();

                // 1. 时间过滤
                query = query.Where(l => l.LogTime >= start && l.LogTime <= end);

                // 2. 关键词过滤 (搜用户名或操作类型)
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(l => l.UserName.Contains(keyword) || l.Operation.Contains(keyword));
                }

                // 3. 按时间倒序 (最新的在最上面)
                return query.OrderByDescending(l => l.LogTime).ToList();
            }
        }

    }
}
