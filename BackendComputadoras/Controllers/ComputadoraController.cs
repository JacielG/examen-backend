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
    public class ComputadoraController : Controller
    {
        private readonly BackendComputadorasDataContext _baseDatos;
        private readonly ComputadoraApplicationService _computadoraApplicationService;
        public ComputadoraController(BackendComputadorasDataContext _context, ComputadoraApplicationService computadoraApplicationService)
        {
            _baseDatos = _context;
            _computadoraApplicationService = computadoraApplicationService;

            if (_baseDatos.Computadoras.Count() == 0)
            {
                _baseDatos.Computadoras.Add(new Computadora { nombre = "ROG750", tipoDisco = "SSD", precio = "999.99", marcaId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computadora>>> GetComputadoras()
        {
            return await _baseDatos.Computadoras.Include(q => q.Marca).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Computadora>> GetComputadora(int id)
        {
            var respuestaComputadoraApplicationService = await _computadoraApplicationService.GetComputadoraApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaComputadoraApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Computadoras.Include(q => q.Marca).FirstOrDefaultAsync(q => q.id == id); ;
            }
            return BadRequest(respuestaComputadoraApplicationService);
        }

        [HttpPost]
        public async Task<ActionResult<Computadora>> PostComputadora(Computadora computadora)
        {
            var respuestaComputadoraApplicationService = await _computadoraApplicationService.PostComputadoraApplicationService(computadora);

            bool noHayErroresEnValidaciones = respuestaComputadoraApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetComputadora), new { id = computadora.id }, computadora);
            }
            return BadRequest(respuestaComputadoraApplicationService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Computadora computadora)
        {
            var respuestaComputadoraApplicationService = await _computadoraApplicationService.PutComputadoraApplicationService(id, computadora);

            bool noHayErroresEnValidaciones = respuestaComputadoraApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaComputadoraApplicationService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var respuestaComputadoraApplicationService = await _computadoraApplicationService.DeleteComputadoraApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaComputadoraApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaComputadoraApplicationService);
        }
    }
}
