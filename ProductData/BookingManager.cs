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
            return db.Bookings.Include(p => p.Package).Include(tt => tt.TripType).Where(b => b.CustomerId == custID).ToList();
        }
        
        /// <summary>
        /// Adds new booking
        /// </summary>
        /// <param name="booking">Booking to add</param>
        public static void AddBooking(Booking booking)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        /// <summary>
        /// Gets the most recent booking id
        /// </summary>
        /// <returns>Id of most recent booking in an int</returns>
        public static int GetMostRecentBookingID()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            int lastId = db.Bookings.OrderBy(i => i.BookingId).Select(i => i.BookingId).LastOrDefault();
            return lastId;
        }
    }
}
