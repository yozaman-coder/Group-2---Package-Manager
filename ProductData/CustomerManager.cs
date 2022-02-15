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

        public static Customer GetCustomerById(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer customer = db.Customers.Find(id);
            return customer;
        }
    }
}
