using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;
using OrangeHub.API.Data;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ApontamentoController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ApontamentoController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Apontamento
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Apontamento>>> GetApontamentos()
    {
      return await _context.Apontamentos
          .Include(a => a.Usuario)
          .Include(a => a.EscritorioId)
          .ToListAsync();
    }

    // GET: api/Apontamento/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Apontamento>> GetApontamento(int id)
    {
      var apontamento = await _context.Apontamentos
          .Include(a => a.Usuario)
          .Include(a => a.EscritorioId)
          .FirstOrDefaultAsync(a => a.Id == id);

      if (apontamento == null)
        return NotFound();

      return apontamento;
    }

    // POST: api/Apontamento
    [HttpPost]
    public async Task<ActionResult<Apontamento>> PostApontamento(Apontamento apontamento)
    {
      _context.Apontamentos.Add(apontamento);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetApontamento), new { id = apontamento.Id }, apontamento);
    }

    // PUT: api/Apontamento/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApontamento(int id, Apontamento apontamento)
    {
      if (id != apontamento.Id)
        return BadRequest();

      _context.Entry(apontamento).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/Apontamento/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApontamento(int id)
    {
      var apontamento = await _context.Apontamentos.FindAsync(id);
      if (apontamento == null)
        return NotFound();

      _context.Apontamentos.Remove(apontamento);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
