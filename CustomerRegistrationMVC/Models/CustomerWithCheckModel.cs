using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.Models
{
    /*
     * Customer model with added checking of password
     * 
     * Author James Straka
     */
    public class CustomerWithCheckModel
    {
        public Customer Customer { get; set; }

        public string PassCheck { get; set; }

    }
}
