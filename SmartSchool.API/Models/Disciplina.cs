using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models{
    public class Disciplina{
        public Disciplina(){
        }

        public Disciplina(int id, string nome, int myProperty){
            this.Id = id;
            this.Nome = nome;
            this.MyProperty = myProperty;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MyProperty { get; set; }
        public int ProfessorId;
        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
