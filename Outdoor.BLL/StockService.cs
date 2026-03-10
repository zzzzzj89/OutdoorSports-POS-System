using Outdoor.DAL;
using Outdoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.BLL
{
    public class StockService
    {
        private StockDAL _stockDAL = new StockDAL();
        private LogService _logService = new LogService();
        private UserDAL _userDAL = new UserDAL();



        public int GetCurrentStock(int storeId, int productId)
        {
            return _stockDAL.GetStockQuantity(storeId, productId);
        }

        public bool StockIn(int storeId, int productId, int count, string userName, out string msg)
        {
            var user = GlobalContext.CurrentUser;
            msg = "";
            if (count <= 0)
            {
                msg = "入库数量必须大于0！";
                return false;
            }
            else
            {
                _stockDAL.IncreaseStock(storeId, productId, count);
                LogDAL.AddLog(
                user.RealName,
                "商品入库",
                $"商品ID: {productId}, 入库数量: {count}, 仓库ID: {storeId}"
            );
                return true;

            }

        }



    }
}
