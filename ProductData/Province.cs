using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public class Province
    {
        public Province(string ProvID, string Province)
        {
            this.Value = ProvID;
            this.Text = Province;
        }
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
