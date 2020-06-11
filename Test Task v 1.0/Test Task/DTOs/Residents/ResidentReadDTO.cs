using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task.DTOs.Residents
{
    public class ResidentReadDTO
    {
        public int ID_Reasident { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalNo { get; set; }
        public DateTime BirthDat { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int ID_Apartment { get; set; }
    }
}
