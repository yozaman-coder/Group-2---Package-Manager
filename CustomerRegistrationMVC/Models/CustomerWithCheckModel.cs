using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationMVC.Models
{
    public class CustomerWithCheckModel
    {
        public Customer Customer { get; set; }

        public string PassCheck { get; set; }

    }
}
