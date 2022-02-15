using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductData;
using System;
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
