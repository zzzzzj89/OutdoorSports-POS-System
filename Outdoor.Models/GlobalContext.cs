using Outdoor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.Models
{
    public static class GlobalContext
    {
        public static SysUser CurrentUser  { get; set; }

        public static SysStore CurrentStore { get; set; }
    }
}
