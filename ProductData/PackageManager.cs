using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class PackageManager
    {
        /// <summary>
        /// Returns all packages within specified range
        /// </summary>
        /// <param name="priceMin">Min price to sort with</param>
        /// <param name="priceMax">Max price to sort with</param>
        /// <returns>All packages within specified range</returns>
        public static List<Package> GetPackagesByPriceRange(decimal priceMin, decimal priceMax)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            List<Package> packagesWithinRange = db.Packages
                .OrderBy(p => p.PkgBasePrice)
                .Where(p => p.PkgBasePrice >= priceMin && p.PkgBasePrice <= priceMax)
                .ToList();
            return packagesWithinRange;
        }

        public static List<Package> GetAllPackages()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.ToList();
        }

        public static Package GetPackageById(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.Find(id);
        }

        public static List<Package> GetCurrentPackages()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.Where(p => p.PkgEndDate >= DateTime.Now).ToList();
        }
    }
}
