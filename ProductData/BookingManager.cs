using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class BookingManager
    {
        /// <summary>
        /// Gets bookings with cust id
        /// </summary>
        /// <param name="custID">Cust id to get bookings </param>
        /// <returns>Bookings for respective customer id</returns>
        public static List<Booking> GetBookingsForCustomer(int custID)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            return db.Bookings.Include(bd => bd.BookingDetails).Where(b => b.CustomerId == custID).ToList();
        }
        
    }
}
