using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL;

namespace Outdoor.BLL
{
    public class ReportService
    {
        private ReportDAL _reportDAL = new ReportDAL();

        // 透传 DAL 层的方法
        public decimal GetTodaySales(int storeId) => _reportDAL.GetTodaySales(storeId);
        public int GetTodayOrderCount(int storeId) => _reportDAL.GetTodayOrderCount(storeId);
        public List<dynamic> GetLowStockList(int storeId) => _reportDAL.GetLowStockItems(storeId);
        public List<TopProductDto> GetTopProducts(int storeId) => _reportDAL.GetTopProducts(storeId);
    }
}
