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

        //// GET: BookingController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
