using ProductData;
using System.Linq;

namespace CustomerRegistrationMVC.Models
{
    public class BookingAndBookingDetailsModel
    {
        public Booking Booking { get; set; }
        public BookingDetail BookingDetail { get; set; }

        public static void Book(BookingAndBookingDetailsModel bookingAndBookingDetailsModel)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var booking = bookingAndBookingDetailsModel.Booking;
            // was using this but turned out to be not usefull 
            //var bookingDetails = bookingAndBookingDetailsModel.BookingDetail; 
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
    }
}
