using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea6Semana6API.Models;
using Microsoft.AspNetCore.Cors;


namespace Tarea6Semana6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UsuarioController : ControllerBase
    {
        private readonly Tarea6Semana6AppContext _context;

        public UsuarioController(Tarea6Semana6AppContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioModel usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Contrasenia) || string.IsNullOrWhiteSpace(usuario.Email))
            {
                return BadRequest(new { message = "El email y la contrasenia son requeridos" });
            }
            var us = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Email == usuario.Email);
            if (us == null)
            {
                return Unauthorized(new { message = "Credenciales invalidas" });
            }
            if (usuario.Contrasenia != us.Contrasenia)
            {
                return Unauthorized(new { message = "Credenciales invalidas" });

            }
            return Ok(new
            {
                id = us.id,
                nombre = us.Nombres,
                email = us.Email,
            });
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuarioModel()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UsuarioModel>> GetUsuarioModel(int id)
        //{
        //    var usuarioModel = await _context.UsuarioModel.FindAsync(id);

        //    if (usuarioModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuarioModel;
        //}

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
        //{
        //    if (id != usuarioModel.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(usuarioModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuarioModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        //{
        //    _context.UsuarioModel.Add(usuarioModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.id }, usuarioModel);
        //}

        // DELETE: api/Usuario/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUsuarioModel(int id)
        //{
        //    var usuarioModel = await _context.UsuarioModel.FindAsync(id);
        //    if (usuarioModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UsuarioModel.Remove(usuarioModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UsuarioModelExists(int id)
        //{
        //    return _context.UsuarioModel.Any(e => e.id == id);
        //}
    }
}
