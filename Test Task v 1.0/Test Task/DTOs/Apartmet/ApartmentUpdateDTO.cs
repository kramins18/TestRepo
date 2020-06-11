using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task.DTOs.Apartmet
{
    public class ApartmentUpdateDTO
    {
        [Required]
        public int ApartmentNumber { get; set; }
        [Required]
        public int ApartmentFloor { get; set; }
        [Required]
        public int RoomCount { get; set; }
        [Required]
        public int ResidentsCount { get; set; }
        [Required]
        public double FullArea { get; set; }
        [Required]
        public double FivingArea { get; set; }
        [Required]
        public int ID_House { get; set; }
    }
}
