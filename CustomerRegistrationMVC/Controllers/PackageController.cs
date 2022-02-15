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
            if (package != null)
            {
                var products = PackagesProductsSupplierManager.GetProductsOfPackage(package.PackageId);
                foreach (var product in products)
                {
                    var productSupplier = ProductSupplierManager.GetProductSupplierWithID(product.ProductSupplierId);
                    ProductList.Add(ProductManager.GetProductWithID((int)productSupplier.ProductId));
                }
                ViewBag.ProductList = ProductList;
            }
            ViewBag.PageTracker = pageTracker;
            return View(package);
        }
        // Get list of all packages as key:value pairs
        private IEnumerable GetPackagesWithAll()
        {
            var packages = PackageManager.GetPackagesAsKeyValuePairs();
            var list = new SelectList(packages, "Value", "Text").ToList();
            list.Insert(0, new SelectListItem { Value = "0", Text = "All" });
            return list;
        }

        public ActionResult PackagesSortingByPrice()
        {
            try
            {
                ViewBag.Packages = GetPackagesWithAll();
                return View();
            }
            catch (Exception)
            {
                TempData["Message"] = "Database connection problem. Try again later.";
                TempData["IsError"] = true;
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult PackagesByPrice(decimal min, decimal max)
        {
            return ViewComponent("PackagesSorting", new { min, max});
        }

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
