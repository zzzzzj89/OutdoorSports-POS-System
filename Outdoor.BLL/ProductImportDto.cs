using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes; // 引用 MiniExcel

namespace Outdoor.BLL
{
    // 这个类用来映射 Excel 的列
    public class ProductImportDto
    {
        [ExcelColumnName("商品名称")]
        public string ProductName { get; set; }

        [ExcelColumnName("条形码")]
        public string Barcode { get; set; }

        [ExcelColumnName("分类")]
        public string Category { get; set; }

        [ExcelColumnName("品牌")]
        public string Brand { get; set; }

        [ExcelColumnName("零售价")]
        public decimal UnitPrice { get; set; }

        [ExcelColumnName("成本价")]
        public decimal CostPrice { get; set; }

        [ExcelColumnName("规格")]
        public string Spec { get; set; }
    }
}
