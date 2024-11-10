using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeHub.API.Data;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EscritorioController : ControllerBase
  {
    private readonly AppDbContext _context;

    public EscritorioController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Escritorio
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Escritorio>>> GetEscritorios()
    {
      return await _context.Escritorios.ToListAsync();
    }

    // GET: api/Escritorio/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Escritorio>> GetEscritorio(int id)
    {
      var escritorio = await _context.Escritorios.FindAsync(id);
      if (escritorio == null)
        return NotFound();

      return escritorio;
    }

    // POST: api/Escritorio
    [HttpPost]
    public async Task<ActionResult<Escritorio>> PostEscritorio(Escritorio escritorio)
    {
      _context.Escritorios.Add(escritorio);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetEscritorio), new { id = escritorio.Id }, escritorio);
    }

    // PUT: api/Escritorio/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEscritorio(int id, Escritorio escritorio)
    {
      if (id != escritorio.Id)
        return BadRequest();

      _context.Entry(escritorio).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/Escritorio/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEscritorio(int id)
    {
      var escritorio = await _context.Escritorios.FindAsync(id);
      if (escritorio == null)
        return NotFound();

      _context.Escritorios.Remove(escritorio);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
