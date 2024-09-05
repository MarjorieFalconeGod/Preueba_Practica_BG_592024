using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebAPP_20240905_Marjorie_Falcone.Models;
using WebAPP_20240905_Marjorie_Falcone.Services.Usuario;

namespace WebAPP_20240905_Marjorie_Falcone.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            var Usuarios = await _UsuarioService.Crear(usuario);
            return Json(Usuarios);
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar(
       [FromBody] Usuario usuario)
        {
            var Usuarios = await _UsuarioService.Actualizar(usuario);
            return Json(Usuarios);
        }



        [HttpGet]
        public async Task<IActionResult> VerUsuario([FromQuery] int codigo)
        {
            var Usuarios = await _UsuarioService.ver( codigo);
            return Json(Usuarios);
        }

        public async Task<IActionResult> Index()
        {
            var Usuarios = await _UsuarioService.ConsultarTodos();
            return View(Usuarios);
            
        }

        public IActionResult Create()
        {
            return View();
        }



    }
}
