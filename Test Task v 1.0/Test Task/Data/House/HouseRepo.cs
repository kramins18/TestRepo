using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Models;

namespace Test_Task.Data
{
    public class HouseRepo : IHouseRepo
    {
        private readonly Context _context;
        public HouseRepo(Context context)
        {
            _context = context;
        }

        public void CreateHouse(HouseModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _context.Add(model);

        }

        public void DeleteHouse(HouseModel house)
        {
            if (house == null)
            {
                throw new ArgumentNullException();
            }
            _context.Remove(house);
        }

        public IEnumerable<HouseModel> GetAllHouses()
        {
            return _context.House.ToList();
        }

        public HouseModel GetHouseById(int id)
        {
            return _context.House.FirstOrDefault(p => p.ID_House == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateHouse(HouseModel model)
        {
           
        }
    }
}
