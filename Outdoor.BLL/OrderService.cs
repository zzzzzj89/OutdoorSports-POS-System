using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL;
using Outdoor.DAL.Models;

namespace Outdoor.BLL
{
    public class OrderService
    {
  
            private OrderDAL _orderDAL = new OrderDAL();

            public List<SalesOrder> SearchOrders(DateTime start, DateTime end, string orderNo)
            {
                // 业务逻辑：结束时间通常要设为当天的 23:59:59，否则查不到当天的单
                DateTime realEnd = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59);
                return _orderDAL.GetOrders(start, realEnd, orderNo);
            }

            public List<SalesOrderDetail> GetDetails(int orderId)
            {
                return _orderDAL.GetOrderDetails(orderId);
            }

            public bool Refund(int orderId, out string msg)
            {
                return _orderDAL.ReturnOrder(orderId, out msg);
            }
       

    }
}
