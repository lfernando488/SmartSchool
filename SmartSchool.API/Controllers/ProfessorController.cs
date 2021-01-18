using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SmartSchool.API.DTO;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase{
        
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        //  public ProfessorController(){
        //  }

        public ProfessorController(IRepository repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(){
            var professores = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professores));
        }

        //  [HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null){
                return BadRequest("Professor não encontrado!");
            }

            var professorDto = _mapper.Map<ProfessorDTO>(professor);

            return Ok(professorDto);
        }


        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDTO model){

            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.saveChanges()){
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(professor));
            }

            return BadRequest("Professor não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDTO model)
        {

            var prof = _repo.GetProfessorById(id);
            if (prof == null){
                return BadRequest("Professor não encontrado!");
            }

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.saveChanges()){
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(prof));
            }

            return BadRequest("Professor não pode ser atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDTO model){

            var prof = _repo.GetProfessorById(id);
            if (prof == null){
                return BadRequest("Professor não encontrado!");
            }

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.saveChanges()){
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(prof));
            }

            return BadRequest("Professor não pode ser atualizado!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id){ 

            var professor = _repo.GetProfessorById(id);

            if (professor == null){
                return BadRequest("Professor não encontrado!");
            }

            _repo.Delete(professor);
            if (_repo.saveChanges()){
                return Ok("Registro de professor removido");
            }

            return BadRequest("Registro de professor não pode ser removido");
        }
    }

}
