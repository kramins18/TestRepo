using AutoMapper;
using Test_Task.DTOs.Apartmet;
using Test_Task.DTOs.House;
using Test_Task.DTOs.Residents;
using Test_Task.Models;

namespace Test_Task.Profiles
{
    public class HouseProfiles : Profile
    {
        public HouseProfiles()
        {
            CreateMap<HouseModel,HouseReadDTO>();
            CreateMap<HouseCreateDTO,HouseModel>();
            CreateMap<HouseUpdateDTO, HouseModel>();

            CreateMap<ResidentModel, ResidentReadDTO>();
            CreateMap<ResidentCreateDTO, ResidentModel>();
            CreateMap<ResidentUpdateDTO, ResidentModel>();

            CreateMap<ApartmentModel, ApartmentReadDTO>();
            CreateMap<ApartmentCreateDTO, ApartmentModel>();
            CreateMap<ApartmentUpdateDTO, ApartmentModel>();
        }
        
    }
}
