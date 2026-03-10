using Outdoor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.DAL
{
    public class ReportDAL
    {

        public decimal GetTodaySales(int storeId)
        {
            using(var context = new OutdoorContext())
            {
                var today = DateTime.Today;
                return context.SalesOrders.
                    Where(o => o.StoreId == storeId && o.OrderTime == today)
                    .Sum(o => (decimal?)o.TotalAmount) ?? 0;
            }
        }

        public int GetTodayOrderCount(int storeId)
        {
            using(var context = new OutdoorContext())
            {
                var today = DateTime.Today;
                return context.SalesOrders.Count
                    (o => o.StoreId == storeId && o.OrderTime == today);
            }
        }

        public List<dynamic> GetLowStockItems(int storeId)
        {
            using (var context = new OutdoorContext())
            {
                var query = from s in context.StockInventories
                            join p in context.BaseProducts on s.ProductId equals p.ProductId
                            where s.StoreId == storeId && s.Quantity <= s.MinThreshold
                            select new
                            {
                                ProductName = p.ProductName,
                                Quantity = s.Quantity,
                                MinThreshold = s.MinThreshold
                            };

                return query.ToList<dynamic>();
            }
        }

        public List<TopProductDto> GetTopProducts(int storeId)
        {
            using (var context = new OutdoorContext())
            {
                // 逻辑：
                // 1. 找当前门店的订单 (SalesOrders)
                // 2. 连表找订单明细 (SalesOrderDetails)
                // 3. 连表找商品信息 (BaseProducts)
                // 4. 按商品名分组 (Group By)
                // 5. 算出每组卖了多少个 (Sum Quantity)
                // 6. 降序排列 (OrderByDescending)
                // 7. 取前 5 个 (Take 5)

                var query = from d in context.SalesOrderDetails
                            join o in context.SalesOrders on d.OrderId equals o.OrderId
                            join p in context.BaseProducts on d.ProductId equals p.ProductId
                            where o.StoreId == storeId
                            group d by p.ProductName into g
                            orderby g.Sum(x => x.Quantity) descending
                            select new TopProductDto
                            {
                                ProductName = g.Key,
                                TotalQuantity = g.Sum(x => x.Quantity)
                            };

                return query.Take(5).ToList();
            }
        }

    }
}
