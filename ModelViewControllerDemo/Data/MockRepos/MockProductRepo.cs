using ModelViewControllerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Data.MockRepos
{
    public class MockProductRepo : IProductRepo
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { P_Code = "11GER/G1", P_descript = "Power painter, 15 psi., 3-nozzle", P_InDate = new DateTime(2017, 11, 03), P_QOH = 8  , P_Min = 5         , P_Price = 109.99  , P_Discount = 0    , V_code = 25595 },
            new Product { P_Code = "13-Q2/P2", P_descript = "7.25-in pwr. saw blade",           P_InDate = new DateTime(2017, 12, 13), P_QOH = 32 , P_Min = 15    , P_Price = 14.99   , P_Discount = 0.05 , V_code = 21344 },
            new Product { P_Code = "14-Q1/L3", P_descript = "9.00-in pwr. saw blade",           P_InDate = new DateTime(2017, 11, 13), P_QOH = 18 , P_Min = 12    , P_Price = 17.49   , P_Discount = 0    , V_code = 21344 },
            new Product { P_Code = "1548-QQ2", P_descript = "Hrd. cloth, 1/4-in., 2x50",        P_InDate = new DateTime(2018, 01, 15), P_QOH = 15 , P_Min = 8     , P_Price = 39.95   , P_Discount = 0    , V_code = 23119 },
            new Product { P_Code = "1558-QW1", P_descript = "Hrd. cloth, 1/2-in., 1x50",        P_InDate = new DateTime(2018, 01, 15), P_QOH = 23 , P_Min = 5     , P_Price = 43.99   , P_Discount = 0    , V_code = 23119 },
            new Product { P_Code = "2232/QTY", P_descript = "B&D jigsaw, 12-in. blade",         P_InDate = new DateTime(2017, 12, 30), P_QOH = 8  , P_Min = 5         , P_Price = 109.92  , P_Discount = 0.05 , V_code = 24288 },
            new Product { P_Code = "2232/QWE", P_descript = "B&D jigsaw, 8-in. blade",          P_InDate = new DateTime(2017, 12, 24), P_QOH = 6  , P_Min = 5         , P_Price = 99.87   , P_Discount = 0.05 , V_code = 24288 },
            new Product { P_Code = "2238/QPD", P_descript = "B&D cordless drill, 12-in",        P_InDate = new DateTime(2018, 01, 20), P_QOH = 12 , P_Min = 5     , P_Price = 38.95   , P_Discount = 0.05 , V_code = 25595 },
            new Product { P_Code = "23109-HB", P_descript = "Claw hammer",                      P_InDate = new DateTime(2018, 01, 20), P_QOH = 23 , P_Min = 10        , P_Price = 9.95    , P_Discount = 0.1  , V_code = 21225 },
            new Product { P_Code = "23114-AA", P_descript = "Sledge hammer, 12 lb.",            P_InDate = new DateTime(2018, 01, 02), P_QOH = 8  , P_Min = 5     , P_Price = 14.4    , P_Discount = 0.05 , V_code = null  },
            new Product { P_Code = "54778-2T", P_descript = "Rat-tail file, 1/8-in. fine",      P_InDate = new DateTime(2017, 12, 15), P_QOH = 43 , P_Min = 20        , P_Price = 4.99    , P_Discount = 0    , V_code = 21344 },
            new Product { P_Code = "89-WRE-Q", P_descript = "Hicut chain saw, 16 in.",          P_InDate = new DateTime(2018, 02, 07), P_QOH = 11 , P_Min = 5         , P_Price = 256.99  , P_Discount = 0.05 , V_code = 24288 },
            new Product { P_Code = "PVC23DRT", P_descript = "PVC pipe, 3.5-in, 8-ft",           P_InDate = new DateTime(2018, 02, 20), P_QOH = 188, P_Min = 75    , P_Price = 5.87    , P_Discount = 0    , V_code = null  },
            new Product { P_Code = "SM-18277", P_descript = "1.25-in. metal screw, 25",         P_InDate = new DateTime(2018, 03, 01), P_QOH = 172, P_Min = 75        , P_Price = 6.99    , P_Discount = 0    , V_code = 21225 },
            new Product { P_Code = "SM-23116", P_descript = "2.5-in. wd screw, 50",             P_InDate = new DateTime(2018, 02, 24), P_QOH = 237, P_Min = 100       , P_Price = 8.45    , P_Discount = 0    , V_code = 21231 },
            new Product { P_Code = "WR3/TT3",  P_descript = "Steel matting, 4x8x1/6, .5 mesh",  P_InDate = new DateTime(2018, 01, 17), P_QOH = 18 , P_Min = 5     , P_Price = 119.95  , P_Discount = 0.1  , V_code = 25595 },
        };

        public void Create(Product product)
        {
            _products.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(string id)
        {
            var product = _products
                .Where(p => p.P_Code.Equals(id)).FirstOrDefault();

            return product;
        }
    }
}
