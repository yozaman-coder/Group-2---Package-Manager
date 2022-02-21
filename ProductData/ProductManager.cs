using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class ProductManager
    {
        public static IList GetProductsAsKeyValuePairs()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Products.OrderBy(d => d.ProdName).Select(d => new { Value = d.ProductId, Text = d.ProdName }).ToList();
        }

        public static List<Product> GetAllProducts()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Products.OrderBy(d => d.ProdName).ToList();
        }

        public static Product GetProductWithID(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Products.Find(id);
        }
    }
}
