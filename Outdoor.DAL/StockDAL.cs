using Outdoor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.DAL
{
    public class StockDAL
    {
        public int GetStockQuantity(int storeId, int productId)
        {
            using(var context = new OutdoorContext())
            {
                var stock = context.StockInventories.
                    FirstOrDefault(s => s.StoreId == storeId && s.ProductId == productId);

                return stock == null?0:stock.Quantity.GetValueOrDefault();
            }
        }


        public void IncreaseStock(int storeId, int productId,int count)
        {
            using(var context = new OutdoorContext())
            {
                var stock = context.StockInventories.
                    FirstOrDefault(s => s.StoreId == storeId && s.ProductId == productId);
                if (stock == null)
                {
                    var newStock = new StockInventory
                    {
                        StoreId = storeId,
                        ProductId = productId,
                        Quantity = count,
                        MinThreshold = 10
                    };
                    context.StockInventories.Add(newStock);
                }
                else
                {
                    stock.Quantity += count;
                }

                context.SaveChanges();
            }
        }

    }
}
