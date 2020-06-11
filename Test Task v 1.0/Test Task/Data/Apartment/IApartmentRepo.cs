using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Models;

namespace Test_Task.Data.Apartment
{
    public interface IApartmentRepo
    {
        bool SaveChanges();
        IEnumerable<ApartmentModel> GetAllApartments();
        ApartmentModel GetApartmentByID(int id);
        void CreateApartment(ApartmentModel model);
        void UpdateApartment(ApartmentModel model);
        void DeleteApartment(ApartmentModel model);
    }
}
