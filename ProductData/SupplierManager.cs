using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    /*
     * Class library for working with suppliers
     * 
     * Author James Straka
     * 
     */
    public class SupplierManager
    {
        /// <summary>
        /// Gets all suppliers as key value pairs
        /// </summary>
        /// <returns>All suppliers as key value pairs</returns>
        public static IList GetSuppliersAsKeyValuePairs()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Suppliers.OrderBy(d => d.SupName).Select(d => new { Value = d.SupplierId, Text = d.SupName }).ToList();
        }

        /// <summary>
        /// Gets all suppliers
        /// </summary>
        /// <returns>all suppliers</returns>
        public static List<Supplier> GetAllSuppliers()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Suppliers.OrderBy(d => d.SupName).ToList();
        }

    }
}
