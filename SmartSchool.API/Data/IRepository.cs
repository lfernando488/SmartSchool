using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data{
    public interface IRepository{

        void Add<T>(T entity) where T : class;     
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool saveChanges();
        
        //Alunos
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        //Asincrono
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        //Sincrono
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        
        //Professores
        Professor GetProfessorById(int professorId, bool includeProfessor = false);
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
    
    }
}
