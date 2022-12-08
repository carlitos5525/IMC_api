using System.Collections.Generic;
using System.Linq;
using icm_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace icm_api.Models
{
    [ApiController]
    [Route("api/imc")]
    public class ImcController : ControllerBase
    {
        private readonly DataContext _context;

        //Injeção de dependência - balta.io
        public ImcController(DataContext context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Imc imc)
        {
            
            imc.Imc_resultado =  imc.Peso / imc.Altura;

            if (imc.Imc_resultado <= 18.5)
            {
                imc.Classificacao_IMC = "Magreza";
            }
            else if(imc.Imc_resultado <= 24.9)
            {
                imc.Classificacao_IMC = "Normal";
            }
            else if(imc.Imc_resultado <= 29.9)
            {
                imc.Classificacao_IMC = "Sobrepeso";
            }
            else if(imc.Imc_resultado <= 39.9)
            {
                imc.Classificacao_IMC = "Obesidade";
            }
            else
            {
                imc.Classificacao_IMC = "Obesidade grave";
            }
            
            _context.Imcs.Add(imc);
            _context.SaveChanges();
            return Created("", imc);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Imc> imcs =
                _context.Imcs.Include(f => f.Usuario).ToList();

            if (imcs.Count == 0) return NotFound();

            return Ok(imcs);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            var icm_encontrado = _context.Imcs.Include(u => u.Usuario)
            .FirstOrDefault(f => f.Id == id);
            
            if(icm_encontrado != null)
            {
                return Ok(icm_encontrado);

            }
            else
            {
                return NotFound();
            }

        }

        [HttpPatch]
        [Route("alterar")]
        public IActionResult Palpitar([FromBody] Imc imc)
        {
            _context.Imcs.Update(imc);
            _context.SaveChanges();
            return Ok(imc);
        }

       
    }
}