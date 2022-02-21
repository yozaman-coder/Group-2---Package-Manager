using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class SupplierManager
    {
        public static IList GetSuppliersAsKeyValuePairs()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Suppliers.OrderBy(d => d.SupName).Select(d => new { Value = d.SupplierId, Text = d.SupName }).ToList();
        }

        public static List<Supplier> GetAllSuppliers()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Suppliers.OrderBy(d => d.SupName).ToList();
        }

    }
}
