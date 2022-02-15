using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class ProductSupplierManager
    {
        public static ProductsSupplier GetProductSupplierWithID(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.ProductsSuppliers.Find(id);
        }
    }
}
