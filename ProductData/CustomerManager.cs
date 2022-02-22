using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class CustomerManager
    {
        /// <summary>
        /// Adds customer to db
        /// </summary>
        /// <param name="customer">Customer to add</param>
        public static void AddCustomer(Customer customer)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        /// <summary>
		/// User is authenticated based on credentials and a user returned if exists or null if not.
		/// </summary>
		/// <param name="username">Username as a string</param>
		/// <param name="password">Password as a string</param>
		/// <returns> A user object or null </returns>
		///   /// <remarks>
		/// Add additional for the docs for this application--for developers.
		/// </remarks>
		public static Customer Authenticate(string email, string password)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            // Has to be first or default or picks up two customers if they have the same info
            var user = db.Customers.FirstOrDefault(cst => cst.CustEmail == email
                                            && cst.CustPassword == password);
            return user;// This will either be null or an object


        }
        /// <summary>
        /// Gets customer using their id
        /// </summary>
        /// <param name="id">id of customer you wish to get</param>
        /// <returns>customer object of respective id</returns>
        public static Customer GetCustomerById(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer customer = db.Customers.Find(id);
            return customer;
        }

        /// <summary>
        /// Updates customer information with new customer input
        /// </summary>
        /// <param name="customer">new customer data input</param>
        public static void UpdateCustomer(Customer customer)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer oldCustomerData = (from c in db.Customers
                                        where c.CustomerId == customer.CustomerId
                                        select c).FirstOrDefault();
            oldCustomerData.CustEmail = customer.CustEmail;
            oldCustomerData.CustAddress = customer.CustAddress;
            oldCustomerData.CustBusPhone = customer.CustBusPhone;
            oldCustomerData.CustFirstName = customer.CustFirstName;
            oldCustomerData.CustLastName = customer.CustLastName;
            oldCustomerData.CustCity = customer.CustCity;
            oldCustomerData.CustProv = customer.CustProv;
            oldCustomerData.CustPostal = customer.CustPostal;
            oldCustomerData.CustPassword = customer.CustPassword;
            db.SaveChanges();
        }

        /// <summary>
        /// Gets last customer in db
        /// </summary>
        /// <returns>last customer id in db</returns>
        public static int GetLastCustomer()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer result = db.Customers.OrderBy(c => c.CustomerId).LastOrDefault();
            return result.CustomerId;
        }

        /// <summary>
        /// Gets customer email with id
        /// </summary>
        /// <param name="customerId">id to find customer email</param>
        /// <returns>Customer email with respective id</returns>
        public static string GetCustEmail(int customerId)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            string result = db.Customers.Where(c => c.CustomerId == customerId).Select(c => c.CustEmail).ToString();
            return result;
        }

        /// <summary>
        /// Checks for customer with specific email
        /// </summary>
        /// <param name="custEmail">Email to check</param>
        /// <returns>true if customer with email was found false if not</returns>
        public static bool SearchForCustEmail(string custEmail)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            bool result = (from c in db.Customers
                           where c.CustEmail == custEmail
                           select c).Any();
                //db.Customers.FirstOrDefault(c => c.CustEmail == custEmail).CustEmail
            return result;
        }
    }
}
