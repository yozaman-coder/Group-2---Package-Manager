using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CustomerRegistrationMVC.Controllers
{
    /*
     * Package controller for displaying package details and packages
     * 
     * Author James Straka, Brett Dawson
     */
    public class PackageController : Controller
    {
        // GET: PackageController
        public ActionResult Index()
        {
            var packages = PackageManager.GetCurrentPackages();
            return View(packages);
        }

        // GET: PackageController/Details/5
        public ActionResult Details(int id, int pageTracker)
        {
            List<Product> ProductList = new List<Product>();
            var package = PackageManager.GetPackageById(id);

            if (package != null) // There is a package with that id
            {
                // Gets all products of package to list and then sends them all to viewbag
                var products = PackagesProductsSupplierManager.GetProductsOfPackage(package.PackageId);
                foreach (var product in products)
                {
                    var productSupplier = ProductSupplierManager.GetProductSupplierWithID(product.ProductSupplierId);
                    ProductList.Add(ProductManager.GetProductWithID((int)productSupplier.ProductId));
                }
                ViewBag.ProductList = ProductList; 
            }
            ViewBag.PageTracker = pageTracker; // Sends page tracker to page for changing items based on what page the user came from
            return View(package);
        }

        // Get list of all packages as key value pairs for select list
        private IEnumerable GetPackagesWithAll()
        {
            var packages = PackageManager.GetPackagesAsKeyValuePairs();
            var list = new SelectList(packages, "Value", "Text").ToList();
            list.Insert(0, new SelectListItem { Value = "0", Text = "All" });
            return list;
        }

        private List<Tuple<decimal, decimal>> PackagePriceRanges()
        {
            var priceRanges = new List<Tuple<decimal, decimal>>
            {
                Tuple.Create(0m, 1000m),
                Tuple.Create(1000m, 2000m),
                Tuple.Create(2000m, 3000m),
                Tuple.Create(3000m, 4000m),
                Tuple.Create(4000m, 5000m)
            };
            // build list of prices that will be used to populate dropdown menu
            return priceRanges;

        }

       
        public ActionResult PackagesSortingByPrice(decimal min = 0, decimal max = 0)
        {
            try
            {
                ViewBag.Packages = GetPackagesWithAll();
                ViewBag.PriceRanges = PackageManager.GetPackagesByPriceRange(min,max);
                return View("PackagesSortingByPrice");
            }
            catch (Exception)
            {
                TempData["Message"] = "Database connection problem. Try again later.";
                TempData["IsError"] = true;
                return RedirectToAction("_Index");
            }
        }

        public ActionResult PackagesByPrice(decimal min, decimal max)
        {
            return ViewComponent("PackagesSorting", new { min, max});
        }

        //public ActionResult PackagesSortingByPrice()
        //{
        //    Tuple<List<decimal>, List<Package>> tuple;
        //    tuple = new Tuple<List<decimal,decimal>, List<Package>(PackageManager.PackagePriceRanges(), PackageManager.GetCurrentPackages());
                
        //      return View("PackagesSortingByPrice", tuple);
        //}

        //// GET: PackageController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PackageController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PackageController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PackageController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PackageController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PackageController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PackageController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
