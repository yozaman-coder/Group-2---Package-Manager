using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public static class TripTypeManager
    {
        public static IList GetAllAsKeyValuePairs()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var types = db.TripTypes.Select(t => new {
                Value = t.TripTypeId,
                Text = t.Ttname
            }).ToList();
            return types;
        }
    }
}
