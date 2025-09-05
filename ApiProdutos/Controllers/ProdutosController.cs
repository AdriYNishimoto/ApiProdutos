using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using ApiProdutos.Models;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProdutosController> _logger;

        //A injeção de dependencia fornece a instancia do AppDbContext aqui
        public ProdutosController(AppDbContext context, ILogger<ProdutosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/produtos
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            _logger.LogInformation("Buscando produto com ID {ProdutoId}", id);
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                _logger.LogWarning("Produto com ID {ProdutoId} não encontrado", id);
                return NotFound(); // Retorna 404 se o produto não for encontrado
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto); // Retorna 201
        }


        // PUT: api/produtos
        [HttpPut]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest(); // Retorna 400 se o ID na URL não corresponder ao ID do produto
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Produtos.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent(); //Retorna 204
        }

        //DELETE: api/produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id); 
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
