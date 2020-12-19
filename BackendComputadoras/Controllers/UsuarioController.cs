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
    public class UsuarioController : Controller
    {
        private readonly BackendComputadorasDataContext _baseDatos;
        private readonly UsuarioApplicationService _usuarioAppService;
        public UsuarioController(BackendComputadorasDataContext context, UsuarioApplicationService usuarioAppService)
        {
            _baseDatos = context;
            _usuarioAppService = usuarioAppService;

            if (_baseDatos.Usuarios.Count() == 0)
            {
                _baseDatos.Usuarios.Add(new Usuario { usuarioId = "jegalc", contrasena = "123", estaActivo = true });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _baseDatos.Usuarios.ToListAsync();
        }

        [HttpGet("{usuarioId}/{contrasenia}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string usuarioId, string contrasenia)
        {
            var response = await _usuarioAppService.TieneAccesoUsuario(usuarioId, contrasenia);

            if (response != "success")
            {
                return BadRequest(response);

            }
            return Ok("success");
        }
    }
}
