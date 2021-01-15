using Microsoft.AspNetCore.Mvc;
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


        private readonly SmartContext _context;

        public AlunoController(SmartContext context){
            _context = context;
        }

     //   public AlunoController(){
      //  }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Alunos);
        }

        //  [HttpGet("{id:int}")]
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id){

            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null){
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(aluno);
        }

        [HttpGet("{byName}")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {

            var aluno = _context.Alunos.FirstOrDefault(a =>
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome)
            );

            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Aluno aluno)
        {

            return Ok();
        }
    }
}
