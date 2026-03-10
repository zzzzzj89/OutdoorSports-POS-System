using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL.Models;
using Outdoor.Models;

namespace Outdoor.DAL
{
    public class UserDAL
    {
        public SysUser GetUserByUsername (string username)
        {
            using(var context = new OutdoorContext())
            {
                return context.SysUsers.FirstOrDefault(u => u.Username == username);
            }
        }

        public SysStore GetStoreById(int storeId)
        {
            using (var context = new OutdoorContext())
            {
                return context.SysStores.FirstOrDefault(s => s.StoreId == storeId);
            }
        }



    }
}
