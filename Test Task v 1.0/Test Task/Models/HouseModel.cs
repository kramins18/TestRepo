
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Task.Models
{
    public class HouseModel
    {
        [Key]
        public int ID_House { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostIndex { get; set; }

        public ICollection<ApartmentModel> Apartments { get; set; }

    }
}
