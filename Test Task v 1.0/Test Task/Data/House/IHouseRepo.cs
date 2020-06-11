using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Models;

namespace Test_Task.Data
{
    public interface IHouseRepo
    {
        bool SaveChanges();
        IEnumerable<HouseModel> GetAllHouses();
        HouseModel GetHouseById(int id);
        void CreateHouse(HouseModel model);
        void UpdateHouse(HouseModel model);
        void DeleteHouse(HouseModel model);
    }
}
