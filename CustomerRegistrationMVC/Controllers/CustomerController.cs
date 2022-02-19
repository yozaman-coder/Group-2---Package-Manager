using ProductData;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Common;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                Customer customer = new Customer();
                if(HttpContext.Session.GetInt32("CurrentCustomer") != null)
                {
                    ViewBag.CustomerID = HttpContext.Session.GetInt32("CurrentCustomer");
                    customer = CustomerManager.GetCustomerById(ViewBag.CustomerID);
                    ViewBag.CustomerEmail = customer.CustEmail;
                }
                ViewBag.Provinces = GetProvinces();
                return View(customer);
            }
            catch (Exception)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index", "Home");
            }
         
        }

        // Gets all provinces 
        private SelectList GetProvinces()
        {
            List<Province> list = new List<Province>();
            list.Add(new Province("AB", "Alberta"));
            list.Add(new Province("BC", "British Columbia"));
            list.Add(new Province("MB", "Manitoba"));
            list.Add(new Province("NB", "New Brunswick"));
            list.Add(new Province("NF", "Newfoundland"));
            list.Add(new Province("NT", "Northwest Territories"));
            list.Add(new Province("NS", "Nova Scotia"));
            list.Add(new Province("NU", "Nunavut"));
            list.Add(new Province("ON", "Ontario"));
            list.Add(new Province("PE", "Prince Edward Island"));
            list.Add(new Province("PQ", "Quebec"));
            list.Add(new Province("SK", "Saskatchewan"));
            list.Add(new Province("YT", "Yukon"));
            var provSelect = new SelectList(list, "Value", "Text");
            return provSelect;
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int CustID = customer.CustomerId;
                    if(CustID != 0)
                    {
                        CustomerManager.UpdateCustomer(customer);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //Adds customer with the form data
                        CustomerManager.AddCustomer(customer);
                        return RedirectToAction("Index", "Home");
                    }
                    
                   
                }
                catch (DbException)
                {
                    TempData["IsError"] = true;
                    TempData["Message"] = "Database connection error. Try again later...";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
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
