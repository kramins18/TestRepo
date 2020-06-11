using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Data.Apartment;
using Test_Task.Models;

namespace Test_Task.Data
{
    public class ApartmentRepo : IApartmentRepo
    {
        private readonly Context _context;
        public ApartmentRepo(Context context)
        {
            _context = context;
        }
        public void CreateApartment(ApartmentModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _context.Add(model);
        }
        public void DeleteApartment(ApartmentModel house)
        {
            if (house == null)
            {
                throw new ArgumentNullException();
            }
            _context.Remove(house);
        }
        public IEnumerable<ApartmentModel> GetAllApartments()
        {
            return _context.Apartments.ToList();
        }
        public ApartmentModel GetApartmentByID(int id)
        {
            return _context.Apartments.FirstOrDefault(p => p.ID_Apartment == id);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void UpdateApartment(ApartmentModel model)
        {
            //
        }

    }
}

