using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.DTOs.Residents;
using Test_Task.Models;

namespace Test_Task.Data.Resident
{
    public interface IResidentRepo
    {
        void SaveChanges();
        ResidentModel GetResidentByID(int id);
        IEnumerable<ResidentModel> GetAllResidents();
        void UpdateResident(ResidentModel model);
        void CreateResident(ResidentModel model);
        void DeleteResident(ResidentModel model);

    }
}
