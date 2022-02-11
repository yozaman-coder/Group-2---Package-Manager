using Microsoft.AspNetCore.Mvc;
using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.ViewComponents
{
    public class PackagesSorting : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(decimal min, decimal max, int sortType)
        {
            List<Package> packages;

            if (sortType == 0) // User is sorting by decimal
            {
                if(min == 0 && max == 0)
                {
                    // Get all travel packages
                    packages = PackageManager.GetAllPackages();
                }
                else
                {
                    // Get travel packages within range
                    packages = PackageManager.GetPackagesByPriceRange(min, max);
                } 
            }
            if (sortType == 1) // User is sorting by another option
            {

            }

            return View();
        }
    }
}
