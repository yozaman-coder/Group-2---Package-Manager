using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    /*
     * Class library for working with products
     * 
     * Author James Straka
     */
    public class ProductManager
    {
        /// <summary>
        /// Gets products as key value pairs
        /// </summary>
        /// <returns>products as key value pairs</returns>
        public static IList GetProductsAsKeyValuePairs()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Products.OrderBy(d => d.ProdName).Select(d => new { Value = d.ProductId, Text = d.ProdName }).ToList();
        }
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>all products</returns>
        public static List<Product> GetAllProducts()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Products.OrderBy(d => d.ProdName).ToList();
        }
        /// <summary>
        /// Gets products of respective id
        /// </summary>
        /// <param name="id">id to find product</param>
        /// <returns>product of respective id</returns>
        public static Product GetProductWithID(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Products.Find(id);
        }
    }
}
