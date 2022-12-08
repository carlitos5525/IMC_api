using System.Collections.Generic;
using System.Linq;
using icm_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace icm_api.Models
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        //Injeção de dependência - balta.io
        public UsuarioController(DataContext context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Usuario> usuarios =
                _context.Usuarios.ToList();
            if (usuarios.Count == 0) return NotFound();

            return Ok(usuarios);
        }

       
    }
}