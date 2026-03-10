using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL;
using Outdoor.DAL.Models;

namespace Outdoor.BLL
{
    public class PromotionService
    {

        private PromotionDAL _promoDAL = new PromotionDAL();

        public List<SysPromotion> GetList()
        {
            return _promoDAL.GetPromotions();
        }

        public bool AddPromotion(SysPromotion promo, out string msg)
        {
            msg = "";
            if (promo.DiscountRate <= 0 || promo.DiscountRate >= 1)
            {
                msg = "折扣率必须在 0.1 到 0.99 之间！";
                return false;
            }
            if (promo.EndTime <= promo.StartTime)
            {
                msg = "结束时间必须晚于开始时间！";
                return false;
            }

            _promoDAL.AddPromotion(promo);
            return true;
        }

        public void Delete(int id)
        {
            _promoDAL.DeletePromotion(id);
        }

        // 给收银台用的：计算折后价
        public decimal GetDiscountedPrice(int productId, decimal originalPrice, out string promoName)
        {
            promoName = "";
            var promo = _promoDAL.GetActivePromotion(productId);

            if (promo != null)
            {
                promoName = promo.PromoName; // 返回活动名称
                return originalPrice * promo.DiscountRate;
            }

            return originalPrice; // 没活动，原价返回
        }

    }
}
