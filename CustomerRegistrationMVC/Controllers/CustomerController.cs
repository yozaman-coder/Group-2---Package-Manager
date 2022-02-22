﻿using ProductData;
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
using CustomerRegistrationMVC.Models;
using Microsoft.CSharp.RuntimeBinder;

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
            if(cst == null) // There is no customer with that email and password
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Your login information is incorrect!";
                return View(); // Stay on the login page
            }

            // If you made it here then you have signed in so set the session data for the customer ID
            HttpContext.Session.SetInt32("CurrentCustomer", (int)cst.CustomerId);

            List<Claim> claims = new List<Claim>
            {
                // Make new claims for user
                new Claim(ClaimTypes.Email, cst.CustEmail), 
                new Claim(ClaimTypes.Name, cst.CustFirstName), 
                new Claim("LastName", cst.CustLastName), 
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies"); // Cookies authentication
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity); // Cookies authentication

            await HttpContext.SignInAsync("Cookies", claimsPrincipal);

            if(TempData["ReturnUrl"] == null) // There is no return url
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Return to previous page
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            // Logout user and clear session data
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
                CustomerWithCheckModel customer = new CustomerWithCheckModel(); // Make new empty customer
                if(HttpContext.Session.GetInt32("CurrentCustomer") != null) // Customer is signed in
                {
                    ViewBag.CustomerID = HttpContext.Session.GetInt32("CurrentCustomer"); //Give customer ID to view bag
                    customer.Customer = CustomerManager.GetCustomerById(ViewBag.CustomerID); // Gets current customer and sets it to customer
                    ViewBag.CustomerEmail = customer.Customer.CustEmail; // gives customer email to view bag
                }
                ViewBag.Provinces = GetProvinces(); // Gets all provinces for display in dropdown
                return View(customer);
            }
            catch (DbException)
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["IsError"] = true;
                TempData["Message"] = "Database connection error. Try again later...";
                return RedirectToAction("Index", "Home");
            }
         
        }

        // Seeds list of provinces and returns Select List
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
        public ActionResult Create(CustomerWithCheckModel newCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int CustID = newCustomer.Customer.CustomerId;
                    if (CustID != 0) // There is a customer already signed in
                    {
                        if(newCustomer.Customer.CustPassword != newCustomer.PassCheck) // password is not the same as the check
                        {
                            // Redisplay everything with error
                            TempData["IsError"] = true;
                            ViewBag.Provinces = GetProvinces();
                            ViewBag.CustomerID = HttpContext.Session.GetInt32("CurrentCustomer");
                            TempData["Message"] = "Passwords are not the same!";
                            return View(newCustomer);
                        }
                        else
                        {
                            // Update the old customer info
                            CustomerManager.UpdateCustomer(newCustomer.Customer);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    // Check if email exists in db
                    bool dbEmail = CustomerManager.SearchForCustEmail(newCustomer.Customer.CustEmail);
                    if (newCustomer.Customer.CustPassword == newCustomer.PassCheck && dbEmail != true) // Email does not exist in db and password check is good
                    {
                        //Adds customer with the form data
                        CustomerManager.AddCustomer(newCustomer.Customer);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Redisplays page with error if email is taken or passwords are different
                        TempData["IsError"] = true;
                        ViewBag.Provinces = GetProvinces();
                        if (dbEmail == true)
                        {
                            TempData["Message"] = "Email is already taken!";
                        }
                        else
                        {
                            TempData["Message"] = "Passwords are not the same!";
                        }
                        return View(newCustomer);
                    }
                   
                }
                catch (DbException)
                {
                    TempData["IsError"] = true;
                    TempData["Message"] = "Database connection error. Try again later...";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
