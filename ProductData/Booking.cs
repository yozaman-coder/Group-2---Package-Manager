﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductData
{
    [Index(nameof(CustomerId), Name = "BookingsCustomerId")]
    [Index(nameof(CustomerId), Name = "CustomersBookings")]
    [Index(nameof(PackageId), Name = "PackageId")]
    [Index(nameof(PackageId), Name = "PackagesBookings")]
    [Index(nameof(TripTypeId), Name = "TripTypesBookings")]
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        [Key]
        public int BookingId { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime? BookingDate { get; set; }
        [StringLength(50)]
        public string BookingNo { get; set; }
        [Range(1, 50)]
        [Display(Name = "Traveler Count")]
        public double? TravelerCount { get; set; }
        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; }
        [StringLength(1)]
        [Display(Name = "Trip Type")]
        public string TripTypeId { get; set; }
        [Display(Name = "Package ID")]
        public int? PackageId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Bookings")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(PackageId))]
        [InverseProperty("Bookings")]
        public virtual Package Package { get; set; }
        [ForeignKey(nameof(TripTypeId))]
        [InverseProperty("Bookings")]
        public virtual TripType TripType { get; set; }
        [InverseProperty(nameof(BookingDetail.Booking))]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
