using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.Controllers
{
    public class BookingController : Controller
    {
        // GET: BookingController
        [Authorize]
        public ActionResult Index() // Gets bookings for logged in customer
        {
            int? customer = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customer == null) // There is no customer somehow
                customer = 0;// Show blank data
            var bookings = BookingManager.GetBookingsForCustomer((int)customer);
            return View(bookings);
        }

        //// GET: BookingController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: BookingController/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            Package package = PackageManager.GetPackageById(id);
            int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customerId == null)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Error no customer found. Try again later...";
                return RedirectToAction("Index");
            }
            ViewBag.Package = package;
            TempData["BookingDate"] = DateTime.Now;
            TempData["BookingDateDisplay"] = DateTime.Now.ToString();
            TempData["PackageID"] = package.PackageId;
            TempData["CustomerID"] = customerId;
            return View(new Booking());
        }

        //POST: BookingController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       [Authorize]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: BookingController/Edit/5
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

        //// GET: BookingController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BookingController/Delete/5
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
