using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task.Models
{
    public class ApartmentModel
    {
        [Key]
        public int ID_Apartment { get; set; }
        public int ApartmentNumber { get; set; }
        public int ApartmentFloor {  get; set; }
        public int RoomCount { get; set; }
        public int ResidentsCount { get; set; }
        public double FullArea { get; set; }
        public double FivingArea { get; set; }

        [ForeignKey("House")]
        public int ID_House { get; set; }

        public HouseModel House { get; set; }
        public ICollection<ResidentModel> Residents { get; set; }



    }
}
