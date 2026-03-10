using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Outdoor.DAL
{
    public class PromotionDAL
    {
        // 1. 获取促销列表 (包含商品信息)
        public List<SysPromotion> GetPromotions()
        {
            using (var context = new OutdoorContext())
            {
                // 记得去 Models/SysPromotion.cs 检查有没有 public virtual BaseProduct Product { get; set; }
                // 如果没有，手动补上，或者暂时不Include，只显示ID
                return context.SysPromotions
                    .Include(p => p.Product)
                    .OrderByDescending(p => p.StartTime)
                    .ToList();
            }
        }

        // 2. 添加促销
        public void AddPromotion(SysPromotion promo)
        {
            using (var context = new OutdoorContext())
            {
                context.SysPromotions.Add(promo);
                context.SaveChanges();
            }
        }


        // 3. 停用/删除促销
        public void DeletePromotion(int id)
        {
            using (var context = new OutdoorContext())
            {
                var p = context.SysPromotions.Find(id);
                if (p != null)
                {
                    context.SysPromotions.Remove(p); // 物理删除
                    // 或者 p.IsActive = 0; // 逻辑删除
                    context.SaveChanges();
                }
            }
        }

        // [核心] 4. 检查某商品当前是否有有效促销
        public SysPromotion GetActivePromotion(int productId)
        {
            using (var context = new OutdoorContext())
            {
                var now = DateTime.Now;
                return context.SysPromotions
                    .FirstOrDefault(p => p.ProductId == productId
                                      && p.IsActive == 1
                                      && p.StartTime <= now
                                      && p.EndTime >= now);
            }
        }

    }
}
