using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.DTOs.Residents;
using Test_Task.Models;

namespace Test_Task.Data.Resident
{
    public class ResidentRepo : IResidentRepo
    {
        private Context _context;

        public ResidentRepo(Context context)
        {
            _context = context;
        }
        public void CreateResident(ResidentModel model)
        {
            if (model != null)
            {
                throw new ArgumentNullException();
            }
            _context.Add(model);
        }

        public void DeleteResident(ResidentModel model)
        {
            _context.Remove(model);
        }

        public IEnumerable<ResidentModel> GetAllResidents()
        {
            return _context.Residents.ToList();
        }

        public ResidentModel GetResidentByID(int id)
        {
            return _context.Residents.FirstOrDefault(c => c.ID_Reasident == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateResident(ResidentModel model)
        {
            //
        }
    }
}
