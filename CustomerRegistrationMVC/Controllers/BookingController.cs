using CustomerRegistrationMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductData;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.Controllers
{
    /*
     * Booking controller for showing and creating bookings
     * 
     * Author James Straka
     */
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
            decimal totalOwing = 0m;
            foreach(var booking in bookings)
            {
                // If package id exists add price of package to totalOwing
                if(booking.PackageId != null)
                {
                    var package = PackageManager.GetPackageById((int)booking.PackageId);
                    totalOwing += package.PkgBasePrice;
                }
                else
                {
                    totalOwing += 0m;
                }
            }
            // Send total owing to viewbag for display
            ViewBag.Total = totalOwing.ToString("c");
            return View(bookings);
        }

        //// GET: BookingController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // auxilliary method for Create GET
        protected SelectList GetTripTypes()
        {
            // call property types manager to get key/value pairs for property types drop down list 
            var types = TripTypeManager.GetAllAsKeyValuePairs();
            // convert it to a form that drop down list can use, and add to the bag
            var tt = new SelectList(types, "Value", "Text");
            return tt;
        }

        // GET: BookingController/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            try
            {
                BookingAndBookingDetailsModel bookingAndBookingDetailsModel = new BookingAndBookingDetailsModel();
                Package package = PackageManager.GetPackageById(id);
                int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
                // Customer is somehow null. Should not happen
                if (customerId == null)
                {
                    TempData["IsError"] = true;
                    TempData["Message"] = "Error no customer found. Try again later...";
                    return RedirectToAction("Index", "Home");
                }
                int mostRecentID = BookingManager.GetMostRecentBookingID();
                // Send various information to view
                ViewBag.CustomerID = customerId;
                ViewBag.Package = package;
                ViewBag.BookingID = mostRecentID += 1;
                ViewBag.Price = package.PkgBasePrice.ToString("c");
                ViewBag.TripTypes = GetTripTypes();
                ViewBag.Date = DateTime.Now;
                ViewBag.Description = package.PkgDesc;
                return View(bookingAndBookingDetailsModel);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index", "Home");
            }
        }

        //POST: BookingController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       [Authorize]
        public ActionResult Create(BookingAndBookingDetailsModel bookingAndBookingDetailsModel)
        {
            try
            {
                // Book booking
                BookingAndBookingDetailsModel.Book(bookingAndBookingDetailsModel);
                return RedirectToAction(nameof(Index));
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index" , "Home");
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
