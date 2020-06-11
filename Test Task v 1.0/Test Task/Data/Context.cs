using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Models;

namespace Test_Task.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }
        public DbSet<HouseModel> House{ get; set; }
        public DbSet<ApartmentModel> Apartments { get; set;}
        public DbSet<ResidentModel> Residents { get; set; }
    }
}
