using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendComputadoras.ApplicationService;
using BackendComputadoras.DataContext;
using BackendComputadoras.Models;

namespace BackendComputadoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        private readonly BackendComputadorasDataContext _baseDatos;
        private readonly MarcaApplicationService _marcaApplicationService;
        public MarcaController(BackendComputadorasDataContext _context, MarcaApplicationService marcaApplicationService)
        {
            _baseDatos = _context;
            _marcaApplicationService = marcaApplicationService;

            if (_baseDatos.Marcas.Count() == 0)
            {
                _baseDatos.Marcas.Add(new Marca { nombre = "ASUS", anio = "2018" });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            return await _baseDatos.Marcas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var respuestaMarcaApplicationService = await _marcaApplicationService.GetMarcaApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaMarcaApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Marcas.FirstOrDefaultAsync(q => q.id == id); ;
            }
            return BadRequest(respuestaMarcaApplicationService);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            var respuestaMarcaApplicationService = await _marcaApplicationService.PostMarcaApplicationService(marca);

            bool noHayErroresEnValidaciones = respuestaMarcaApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetMarca), new { id = marca.id }, marca);
            }
            return BadRequest(respuestaMarcaApplicationService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, Marca marca)
        {
            var respuestaMarcaApplicationService = await _marcaApplicationService.PutMarcaApplicationService(id, marca);

            bool noHayErroresEnValidaciones = respuestaMarcaApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaMarcaApplicationService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var respuestaMarcaApplicationService = await _marcaApplicationService.DeleteMarcaApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaMarcaApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaMarcaApplicationService);
        }
    }
}
