using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Outdoor.DAL.Models;
using Outdoor.Models;

namespace Outdoor.DAL
{
    public class OrderDAL
    {

        public bool CreateOrder(List<SalesOrderDetail>details,
        string paymentMethod,int?memberId,out string errorMsg)
        {
            errorMsg = "";

            using(var context = new OutdoorContext())
            {

                using(var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var order = new SalesOrder
                        {
                            OrderNo = DateTime.Now.ToString("yyyyMMddHHmmss") +
                            new Random().Next(100, 999),

                            StoreId = GlobalContext.CurrentStore.StoreId,
                            MemberId = memberId,
                            TotalAmount = details.Sum(d => d.Subtotal),
                            ActualAmount = details.Sum(d => d.Subtotal),
                            PaymentMethod = paymentMethod,
                            OrderTime = DateTime.Now,
                            OperatorId = GlobalContext.CurrentUser.UserId
                        };

                        context.SalesOrders.Add(order);
                        context.SaveChanges();

                        foreach(var item in details)
                        {
                            item.OrderId = order.OrderId;
                            context.SalesOrderDetails.Add(item);

                            var stock = context.StockInventories.FirstOrDefault(
                                s => s.StoreId == GlobalContext.CurrentStore.StoreId &&
                                s.ProductId == item.ProductId);

                            if (stock == null||stock.Quantity<item.Quantity)
                            {
                                throw new Exception($"商品ID{item.ProductId}库存不足！" +
                                    $"当前库存:{stock?.Quantity ?? 0}");

                            }
                            stock.Quantity -= item.Quantity;

                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        errorMsg = ex.Message;
                        return false;
                    }
                }
            }
        }


        // [New!] 1. 查询订单列表 (支持按日期和订单号搜索)
        public List<SalesOrder> GetOrders(DateTime start, DateTime end, string orderNo = "")
        {
            using (var context = new OutdoorContext())
            {
                var query = context.SalesOrders
                    .Include(o => o.Store)      // 关联门店信息
                    .Include(o => o.Member)     // 关联会员信息
                    .Where(o => o.OrderTime >= start && o.OrderTime <= end);

                if (!string.IsNullOrEmpty(orderNo))
                {
                    query = query.Where(o => o.OrderNo.Contains(orderNo));
                }

                // 按时间倒序排列
                return query.OrderByDescending(o => o.OrderTime).ToList();
            }
        }

        // [New!] 2. 获取某个订单的详情 (明细)
        public List<SalesOrderDetail> GetOrderDetails(int orderId)
        {
            using (var context = new OutdoorContext())
            {
                return context.SalesOrderDetails
                    .Include(d => d.Product) // 关联商品信息，为了显示商品名
                    .Where(d => d.OrderId == orderId)
                    .ToList();
            }
        }

        // [New!] 3. 退货逻辑 (核心事务)
        public bool ReturnOrder(int orderId, out string msg)
        {
            msg = "";
            using (var context = new OutdoorContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        // A. 找订单
                        var order = context.SalesOrders.FirstOrDefault(o => o.OrderId == orderId);
                        if (order == null) throw new Exception("订单不存在");
                        if (order.Status == 2) throw new Exception("该订单已经退货，不能重复操作");

                        // B. 改状态
                        order.Status = 2; // 设为已退货

                        // C. 库存回滚 (把卖出去的东西加回去)
                        // 先查出这个订单卖了啥
                        var details = context.SalesOrderDetails.Where(d => d.OrderId == orderId).ToList();

                        foreach (var item in details)
                        {
                            // 找到对应门店的库存记录
                            var stock = context.StockInventories
                                .FirstOrDefault(s => s.StoreId == order.StoreId && s.ProductId == item.ProductId);

                            if (stock != null)
                            {
                                stock.Quantity += item.Quantity; // 加库存
                            }
                        }

                        // D. 保存并提交
                        context.SaveChanges();
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        msg = ex.Message;
                        return false;
                    }
                }
            }
        }


    }
}
