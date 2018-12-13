using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade2Parte1Exercicio4.Models
{
    public class Livro
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Nota { get; set; }
        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
