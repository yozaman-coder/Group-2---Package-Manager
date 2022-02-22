using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    /*
     * Class library for working with trip types
     * 
     * Author James Straka
     */
    public static class TripTypeManager
    {
        /// <summary>
        /// Gets all trip types as key value pairs
        /// </summary>
        /// <returns>Returns IList of Pairs of trip types</returns>
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
