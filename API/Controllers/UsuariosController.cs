using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Threading.Tasks;
using OrangeHub.API.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/usuario/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o email já está registrado
            if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                return BadRequest("Email já está em uso.");

            // Adiciona o usuário ao banco de dados
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Registrar), new { id = usuario.Id }, usuario);
        }

        // POST: api/usuario/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login loginRequest)
        {
            // Busca o usuário pelo email
            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(u => u.Email == loginRequest.Email);

            if (usuario == null)
                return Unauthorized("Usuário não encontrado.");

            // Verifica se a senha fornecida é igual à senha armazenada
            if (usuario.Senha != loginRequest.Senha)
                return Unauthorized("Senha incorreta.");

            // Se a autenticação for bem-sucedida, retorna uma mensagem de sucesso
            return Ok(new { Message = "Login realizado com sucesso", Usuario = usuario });
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }
    }
}
