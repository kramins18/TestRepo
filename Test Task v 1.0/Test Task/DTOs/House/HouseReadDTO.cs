using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task.DTOs.House
{
    public class HouseReadDTO
    {
        public int ID_House { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostIndex { get; set; }
    }
}
