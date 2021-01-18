using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.DTO{
    public class AlunoRegistrarDTO{

        /// <summary>
        /// Id unico do aluno para operações no sistema
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Matricula para manutenção academica do registro do aluno
        /// </summary>
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}
