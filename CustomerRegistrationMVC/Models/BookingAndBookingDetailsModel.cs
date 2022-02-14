﻿using ProductData;
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
            var bookingDetails = bookingAndBookingDetailsModel.BookingDetail;
            db.Bookings.Add(booking);
            db.SaveChanges();
            bookingDetails.BookingId = db.Bookings.Where(p => p.BookingId == booking.BookingId).Select(p => p.BookingId).FirstOrDefault();
            db.BookingDetails.Add(bookingDetails);
            db.SaveChanges();
        }
    }
}
