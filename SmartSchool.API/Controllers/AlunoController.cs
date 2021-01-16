using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase{

        private readonly IRepository _repo;

        public AlunoController(IRepository repo){
            _repo = repo;
        }

        //   public AlunoController(){
        //  }

        [HttpGet]
        public IActionResult Get(){
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        //  [HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id){

            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null){
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){

            _repo.Add(aluno);
            if (_repo.saveChanges()){
                return Ok("Aluno cadastrado!");
            }

            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){

            var alu = _repo.GetAlunoById(id);
            if (alu == null){
                return BadRequest("Aluno não encontrado!");
            }

            _repo.Update(aluno);
            if (_repo.saveChanges()){
                return Ok("Registro de aluno atualizado!");
            }

            return BadRequest("Aluno não pode ser atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){

            var alu = _repo.GetAlunoById(id);
            if (alu == null){
                return BadRequest("Aluno não encontrado!");
            }
            _repo.Update(aluno);
            if (_repo.saveChanges()){
                return Ok("Registro de aluno atualizado!");
            }

            return BadRequest("Aluno não pode ser atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){

            var aluno = _repo.GetAlunoById(id);

            if(aluno == null){
                return BadRequest("Aluno não encontrado!");
            }

            _repo.Delete(aluno);
            if (_repo.saveChanges()){
                return Ok("Registro de aluno removido");
            }

            return BadRequest("Registro de aluno não pode ser removido");
        }
    }
}
