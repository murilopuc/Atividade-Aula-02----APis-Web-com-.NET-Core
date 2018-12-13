using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade2Parte1Exercicio4.Models
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }

}
