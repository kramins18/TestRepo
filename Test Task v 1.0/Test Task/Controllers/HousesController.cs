using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Test_Task.Data;
using Test_Task.DTOs.House;
using Test_Task.Models;

namespace Test_Task.Controllers
{
    [Route("/api/house")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHouseRepo _repo;
        private readonly IMapper _mapper;

        public HousesController(IHouseRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HouseReadDTO>> GetAllHouses()
        {
            IEnumerable<HouseModel> houses = _repo.GetAllHouses();
            return Ok(_mapper.Map<IEnumerable<HouseReadDTO>>(houses));
        }

        [HttpGet("{id}", Name = "GetHouseByID")]
        public ActionResult<HouseReadDTO> GetHouseByID(int id)
        {
            HouseModel house = _repo.GetHouseById(id);
            if (house == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HouseReadDTO>(house));
        }

        [HttpPost]
        public ActionResult<HouseReadDTO> CreateHouse(HouseCreateDTO model)
        {
            var houseModel = _mapper.Map<HouseModel>(model);
            _repo.CreateHouse(houseModel);
            _repo.SaveChanges();

            var houseReadDTO = _mapper.Map<HouseReadDTO>(houseModel);
            return CreatedAtRoute(nameof(GetHouseByID), new { ID = houseReadDTO.ID_House }, houseReadDTO);

        }
        [HttpPut("{id}")]
        public ActionResult UpdateHouse(int id, HouseUpdateDTO model)
        {
            var modelFromRepo = _repo.GetHouseById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(model, modelFromRepo);
            _repo.UpdateHouse(modelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteHouse(int id)
        {
            var modelFromRepo = _repo.GetHouseById(id);
            if (modelFromRepo==null)
            {
                return NotFound();
            }
            _repo.DeleteHouse(modelFromRepo);
            _repo.SaveChanges();
            return NoContent();

        }

    }
}