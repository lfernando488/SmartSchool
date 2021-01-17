using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.DTO;
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
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }

        //   public AlunoController(){
        //  }

        [HttpGet]
        public IActionResult Get(){
            var alunos = _repo.GetAllAlunos(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
        }

        //  [HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id){

            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null){
                return BadRequest("Aluno não encontrado!");
            }

            var alunoDto = _mapper.Map<AlunoDTO>(aluno);

            return Ok(alunoDto);
        }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDTO model){

            var aluno = _mapper.Map<Aluno>(model); 

            _repo.Add(aluno);
            if (_repo.saveChanges()){
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }

            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDTO model){

            var aluno = _repo.GetAlunoById(id);
            if (aluno == null){
                return BadRequest("Aluno não encontrado!");
            }

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.saveChanges()){
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }

            return BadRequest("Aluno não pode ser atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDTO model)
        {

            var aluno = _repo.GetAlunoById(id);
            if (aluno == null){
                return BadRequest("Aluno não encontrado!");
            }

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.saveChanges()){
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
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
