using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    /*
     * Class library for working with product suppliers
     * 
     * 
     * Author James Straka
     */
    public class ProductSupplierManager
    {
        /// <summary>
        /// Gets productsSupplier with supplier id
        /// </summary>
        /// <param name="id">Product supplier id</param>
        /// <returns>Product supplier with respective id</returns>
        public static ProductsSupplier GetProductSupplierWithID(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.ProductsSuppliers.Find(id);
        }
    }
}
