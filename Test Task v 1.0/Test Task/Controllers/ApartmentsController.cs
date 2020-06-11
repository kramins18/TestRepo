using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.Data;
using Test_Task.Data.Apartment;
using Test_Task.DTOs.Apartmet;
using Test_Task.Models;

namespace Test_Task.Controllers
{
    [Route("/api/Apartment")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentRepo _repo;
        private readonly IMapper _mapper;
        private readonly IHouseRepo _houseRepo;

        public ApartmentsController(IApartmentRepo repo, IMapper mapper, IHouseRepo houseRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _houseRepo = houseRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ApartmentReadDTO>> GetAllHouses()
        {
            IEnumerable<ApartmentModel> apartments = _repo.GetAllApartments();
            return Ok(_mapper.Map<IEnumerable<ApartmentReadDTO>>(apartments));
        }
        [HttpGet("{id}", Name = "GetApartmentByID")]
        public ActionResult<ApartmentReadDTO> GetApartmentByID(int id)
        {
            ApartmentModel apartment = _repo.GetApartmentByID(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ApartmentModel>(apartment));
        }

        [HttpPost]
        public ActionResult<ApartmentReadDTO> CreateApartment(ApartmentCreateDTO model)
        {
            var apartmentModel = _mapper.Map<ApartmentModel>(model);
            if (_houseRepo.GetHouseById(apartmentModel.ID_House) == null)
            { 
                return BadRequest($"House With ID {model.ID_House} was not found \n Use https://localhost:44359/api/houses from list of avalibale houses! ");
            }        
            _repo.CreateApartment(apartmentModel);
            _repo.SaveChanges();
            var apartmentReadDTO = _mapper.Map<ApartmentReadDTO>(apartmentModel);
            return CreatedAtRoute(nameof(GetApartmentByID), new { ID = apartmentReadDTO.ID_Apartment }, apartmentReadDTO);

        }
        [HttpPut("{id}")]
        public ActionResult UpdateApartment(int id, ApartmentUpdateDTO model)
        {
            var modelFromRepo = _repo.GetApartmentByID(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            if (_houseRepo.GetHouseById(model.ID_House) == null)
            {
                return BadRequest($"House With ID {model.ID_House} was not found \n Use https://localhost:44359/api/houses from list of avalibale houses! ");
            }
            _mapper.Map(model, modelFromRepo);
            _repo.UpdateApartment(modelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteApartment(int id)
        {
            var modelFromRepo = _repo.GetApartmentByID(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteApartment(modelFromRepo);
            _repo.SaveChanges();
            return NoContent();

        }
    }
}
