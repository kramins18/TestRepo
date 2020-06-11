using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task.DTOs.Apartmet
{
    public class ApartmentReadDTO
    {
        public int ID_Apartment { get; set; }
        public int ApartmentNumber { get; set; }
        public int ApartmentFloor { get; set; }
        public int RoomCount { get; set; }
        public int ResidentsCount { get; set; }
        public double FullArea { get; set; }
        public double FivingArea { get; set; }
        public int ID_House { get; set; }
    }
}
