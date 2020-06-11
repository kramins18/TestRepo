using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task.Models
{
    public class ResidentModel
    {
        [Key]
        public int ID_Reasident { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalNo { get; set; }
        public DateTime BirthDat { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        [ForeignKey("Apartment")]
        public int ID_Apartment { get; set; }
        public ApartmentModel Apartment { get; set; }
    }
}
