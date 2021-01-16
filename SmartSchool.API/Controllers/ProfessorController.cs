using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase{
        
        private readonly IRepository _repo;

        //  public ProfessorController(){
        //  }

        public ProfessorController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(){
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        //  [HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null){
                return BadRequest("Professor não encontrado!");
            }
            return Ok(professor);
        }


        [HttpPost]
        public IActionResult Post(Professor professor){
            _repo.Add(professor);
            if (_repo.saveChanges()){
                return Ok("Professor cadastrado!");
            }

            return BadRequest("Professor não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor){

            var prof = _repo.GetProfessorById(id);
            if (prof == null){
                return BadRequest("Professor não encontrado!");
            }

            _repo.Update(professor);
            if (_repo.saveChanges()){
                return Ok("Registro de professor atualizado!");
            }

            return BadRequest("Professor não pode ser atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor){

            var prof = _repo.GetProfessorById(id);
            if (prof == null){
                return BadRequest("Professor não encontrado!");
            }
            _repo.Update(professor);
            if (_repo.saveChanges()){
                return Ok("Registro de professor atualizado!");
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
