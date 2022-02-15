using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductData
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
        }

        [Key]
        public int PackageId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Package Name")]
        public string PkgName { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? PkgStartDate { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? PkgEndDate { get; set; }
        [StringLength(50)]
        [Display(Name = "Package Description")]
        public string PkgDesc { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal PkgBasePrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? PkgAgencyCommission { get; set; }

        // Brett - added Package class constructor
        public Package(int packageId, string pkgName, DateTime? pkgStartDate, DateTime? pkgEndDate, string pkgDesc, decimal pkgBasePrice, decimal? pkgAgencyCommission, ICollection<Booking> bookings, ICollection<PackagesProductsSupplier> packagesProductsSuppliers)
        {
            PackageId = packageId;
            PkgName = pkgName;
            PkgStartDate = pkgStartDate;
            PkgEndDate = pkgEndDate;
            PkgDesc = pkgDesc;
            PkgBasePrice = pkgBasePrice;
            PkgAgencyCommission = pkgAgencyCommission;
            Bookings = bookings;
            PackagesProductsSuppliers = packagesProductsSuppliers;
        }

        [InverseProperty(nameof(Booking.Package))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(PackagesProductsSupplier.Package))]
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
    }
}
