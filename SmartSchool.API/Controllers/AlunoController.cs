using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.DTO;
using SmartSchool.API.Helpers;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase{

        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor AlunoController
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }

        //   public AlunoController(){
        //  }
        
        /// <summary>
        /// Metodo responsavel para retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams){
            var alunos = await _repo.GetAllAlunosAsync(pageParams, true);

            var alunosResult = _mapper.Map<IEnumerable<AlunoDTO>>(alunos);

            Response.AddPagination(alunos.currentPage, alunos.pageSize, alunos.totalCount, alunos.totalPages);

            return Ok(alunosResult);
        }

        /// <summary>
        /// metodo responsavel por retornar aluno pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Metodo repsonsavel pela criação de novo aluno
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDTO model){

            var aluno = _mapper.Map<Aluno>(model); 

            _repo.Add(aluno);
            if (_repo.saveChanges()){
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }

            return BadRequest("Aluno não cadastrado!");
        }


        /// <summary>
        /// Metodo responsavel por alterar o registro de um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo responsavel por alterar parcialmente o registro de um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo responsavel pro remover um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
