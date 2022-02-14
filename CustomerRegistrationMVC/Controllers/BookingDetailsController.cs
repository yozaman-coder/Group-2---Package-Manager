using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.Controllers
{
    public class BookingDetailsController : Controller
    {
        // GET: BookingDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // Display booking details for booking
        // GET: BookingDetailsController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BookingDetail bookingdetails = BookingDetailManager.GetBookingDetailWithBookingID(id);
                TempData["Description"] = bookingdetails.Description;
                return View(bookingdetails);
            }
            catch (Exception)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later.";
                return RedirectToAction("Index", "Home");
            }
        }

        //// GET: BookingDetailsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BookingDetailsController/Create
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

        //// GET: BookingDetailsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BookingDetailsController/Edit/5
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

        //// GET: BookingDetailsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BookingDetailsController/Delete/5
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
