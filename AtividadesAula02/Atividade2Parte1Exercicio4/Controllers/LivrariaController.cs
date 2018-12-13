using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Atividade2Parte1Exercicio4.Models;

namespace LivrariaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly LivroContext _context;

        public LivrariaController(LivroContext context)
        {
            _context = context;

            if (_context.Livros.Count() == 0)
            {
                // Create a new Livro if collection is empty,
                // which means you can't delete all Livros.
                _context.Livros.Add(new Livro { Id = 1, Nome = "Julão", Valor = 8 });
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Consultar todos Livros.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Livro>> GetAll()
        {
            return _context.Livros.ToList();
        }

        /// <summary>
        /// Consultar determinado Livro.
        /// </summary>
        [HttpGet("{id}", Name = "ConsultarLivro")]
        public ActionResult<Livro> GetById(long id)
        {
            var item = _context.Livros.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Criar um novo Livro.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>Criar um novo Livro</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create(Livro item)
        {
            _context.Livros.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        /// <summary>
        /// Comprar um determinado livro.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Update(long id, Livro item)
        {
            var todo = _context.Livros.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Nome = item.Nome;

            _context.Livros.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Avaliar determinado livro.
        /// </summary>
        [HttpPut("{id}, {nota}")]
        public ActionResult Update(long id, decimal nota, Livro item)
        {
            var todo = _context.Livros.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Nome = item.Nome;

            _context.Livros.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletar um livro específico.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Livros.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}