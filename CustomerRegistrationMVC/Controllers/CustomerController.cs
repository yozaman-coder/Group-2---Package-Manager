using ProductData;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.Controllers
{
    public class CustomerController : Controller
    {
        // Route: /Customer/Login
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != null)// Return url exists
                TempData["ReturnUrl"] = returnUrl; //Set tempdata to current url
            else
                TempData["ReturnUrl"] = null;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer customer)
        {
            Customer cst = CustomerManager.Authenticate(customer.CustEmail, customer.CustPassword);
            if(cst == null)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Your login information is incorrect!";
                return View(); // Stay on the login page
            }

            HttpContext.Session.SetInt32("CurrentCustomer", (int)cst.CustomerId);

            List<Claim> claims = new List<Claim>
            {
                // Make new claim for user
                new Claim(ClaimTypes.Email, cst.CustEmail), 
                new Claim(ClaimTypes.Name, cst.CustFirstName), 
                new Claim("LastName", cst.CustLastName), 
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies"); // Cookies authentication
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity); // Cookies authentication

            await HttpContext.SignInAsync("Cookies", claimsPrincipal);

            if(TempData["ReturnUrl"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //// GET: CustomerController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: CustomerController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            try
            {
                if(HttpContext.Session.GetInt32("CurrentCustomer") != null)
                {
                    TempData["IsError"] = true;
                    TempData["Message"] = "You are already signed in!";
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index", "Home");
            }
         
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                //Adds customer with the form data
                CustomerManager.AddCustomer(customer);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index", "Home");
            }
        }

        //// GET: CustomerController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Edit/5
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

        //// GET: CustomerController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Delete/5
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
