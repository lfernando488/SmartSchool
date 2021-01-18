using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.DTO{
    /// <summary>
    /// Objeto de transferencia da model aluno
    /// </summary>
    public class AlunoDTO{
        public AlunoDTO(){
        }
        /// <summary>
        /// Id unico do aluno para operações no sistema
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Matricula para manutenção academica do registro do aluno
        /// </summary>
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; }

    }
}
