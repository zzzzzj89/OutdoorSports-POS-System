using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL; // 引用 DAL
using Outdoor.DAL.Models;

namespace Outdoor.BLL
{
    public class LogService
    {
        // 这是一个“包装”方法
        // UI 层调这个方法，这个方法再去调 DAL
        public void WriteLog(string operation, string details)
        {
            // 这里可以做一些逻辑处理，比如：
            // 如果 details 太长截断一下，或者 console 打印一下方便调试

            // 调用 DAL 层的静态方法 (假设你之前按建议把 LogDAL 写成了 static)
            LogDAL.AddLog(operation, details);


        }

        // [New!] 获取日志列表
        public List<SysLog> SearchLogs(DateTime start, DateTime end, string keyword)
        {
            // 业务逻辑：处理结束时间，让它包含当天的 23:59:59
            DateTime realEnd = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59);

            return LogDAL.GetLogs(start, realEnd, keyword);
        }
    }
}
