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
        private readonly SmartContext _context;

      //  public ProfessorController(){
      //  }

        public ProfessorController(SmartContext context){
            _context = context;

        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id){

            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null){
                return BadRequest("Aluno não encontrado!");
            }
            return Ok(professor);
        }

        [HttpGet("{byName}")]
        public IActionResult GetByName(string nome)
        {

            var professor = _context.Professores.FirstOrDefault(a =>
                a.Nome.Contains(nome)
            );

            if (professor == null)
            {
                return BadRequest("Professor não encontrado!");
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {

            var prof = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado!");
            }

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {

            var prof = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("professor não encontrado!");
            }

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var prof = _context.Alunos.FirstOrDefault(p => p.Id == id);

            if (prof == null){
                return BadRequest("Professor não encontrado!");
            }

            _context.Remove(prof);
            _context.SaveChanges();
            return Ok();
        }
    }

}
