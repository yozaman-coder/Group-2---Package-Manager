using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductData
{
    /*
     * Class library for working with packages
     * 
     * Author James Straka
     * 
     */
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

        /// <summary>
        /// Gets all packages
        /// </summary>
        /// <returns>All packages in list form</returns>
        public static List<Package> GetAllPackages()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.ToList();
        }

        /// <summary>
        /// Gets packages by specified start date
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns>Gets all packages in descending order ell o ell</returns>
        public static List<Package> GetPackagesByStartDate(DateTime startDate)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.OrderByDescending(d => d.PkgStartDate).ToList(); // display most recent at the top
        }

        /// <summary>
        /// Gets package using id
        /// </summary>
        /// <param name="id">id to get package</param>
        /// <returns>Package for the respective id</returns>
        public static Package GetPackageById(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.Find(id);
        }

        /// <summary>
        /// Gets packages that are not expired
        /// </summary>
        /// <returns>all packages that have not expired yet</returns>
        public static List<Package> GetCurrentPackages()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Packages.Where(p => p.PkgEndDate >= DateTime.Now).ToList();
        }

        /// <summary>
        /// Gets all packages as key value pairs
        /// </summary>
        /// <returns>All packages as key value pairs</returns>
        public static IList GetPackagesAsKeyValuePairs()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var packages = db.Packages.OrderBy(p => p.PkgBasePrice).Select(p => new { Value = p.PkgBasePrice, Text = p.PkgName }).ToList();
            return packages;
        }

        //public static List<Tuple<decimal,decimal>> PackagePriceRanges()
        //{
        //    var priceRanges = new List<Tuple<decimal, decimal>> 
        //    { 
        //        Tuple.Create(0m, 1000m),
        //        Tuple.Create(1000m, 2000m), 
        //        Tuple.Create(2000m, 3000m), 
        //        Tuple.Create(3000m, 4000m), 
        //        Tuple.Create(4000m, 5000m)
        //    };
        //    // build list of prices that will be used to populate dropdown menu
        //    return priceRanges;
        //    
        //}
        
    }
}
