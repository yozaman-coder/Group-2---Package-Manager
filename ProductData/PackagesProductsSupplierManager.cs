using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class PackagesProductsSupplierManager
    {
        public static List<PackagesProductsSupplier> GetProductsOfPackage(int packageID)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var productSupplierList = db.PackagesProductsSuppliers.Where(p => p.PackageId == packageID).ToList();
            return productSupplierList;
        }
    }
}
