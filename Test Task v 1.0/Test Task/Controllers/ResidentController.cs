using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Data.Apartment;
using Test_Task.Data.Resident;
using Test_Task.DTOs.Residents;
using Test_Task.Models;

namespace Test_Task.Controllers
{
    [Route("/api/residents")]
    [ApiController]
    public class ResidentController : Controller
    {
        
        private IMapper _mapper;
        private IResidentRepo _repo;
        private IApartmentRepo _apartmentRepo;

        public ResidentController(IMapper mapper, IResidentRepo repo, IApartmentRepo apartmentRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _apartmentRepo = apartmentRepo;

        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ResidentReadDTO>> GetAllResidents()
        {
            
            IEnumerable<ResidentModel> residents = _repo.GetAllResidents();
            return Ok(_mapper.Map<IEnumerable<ResidentModel>>(residents));
        }

        [HttpGet("{id}", Name = "GetResidentByID")]
        public ActionResult<ResidentReadDTO> GetResidentByID(int id)
        {

            ResidentModel resident = _repo.GetResidentByID(id);
            if (resident == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ResidentReadDTO>(resident));
        }

        [HttpPost]
        public ActionResult<ResidentReadDTO> CreateResident(ResidentCreateDTO model)
        {
            var residentModel = _mapper.Map<ResidentModel>(model);
            if (_apartmentRepo.GetApartmentByID(residentModel.ID_Apartment) == null)
            {
                return BadRequest($"Apartment With ID {model.ID_Apartment} was not found \n Use https://localhost:44359/api/apartments from list of avalibale apartments! ");
            }
            _repo.CreateResident(residentModel);
            _repo.SaveChanges();
            var residentReadDto = _mapper.Map<ResidentReadDTO>(residentModel);
            return CreatedAtRoute(nameof(GetResidentByID), new { ID = residentReadDto.ID_Reasident }, residentReadDto);

        }
        [HttpPut("{id}")]
        public ActionResult UpdateResident(int id, ResidentUpdateDTO model)
        {
            var modelFromRepo = _repo.GetResidentByID(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            if (_apartmentRepo.GetApartmentByID(model.ID_Apartment) == null)
            {
                return BadRequest($"Apartment With ID {model.ID_Apartment} was not found \n Use https://localhost:44359/api/apartments from list of avalibale apartments! ");
            }
            _mapper.Map(model, modelFromRepo);
            _repo.UpdateResident(modelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteApartment(int id)
        {
            var modelFromRepo = _repo.GetResidentByID(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteResident(modelFromRepo);
            _repo.SaveChanges();
            return NoContent();

        }

    }
}
