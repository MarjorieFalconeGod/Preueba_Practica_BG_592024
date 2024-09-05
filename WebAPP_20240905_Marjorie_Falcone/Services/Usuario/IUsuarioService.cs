using WebAPP_20240905_Marjorie_Falcone.Models;



using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPP_20240905_Marjorie_Falcone.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<List<Models.Usuario>> ConsultarTodos();

        
        Task<Models.Usuario> Actualizar(Models.Usuario usuario);


        Task<Models.Usuario> ver(int codigo);
        Task Crear(Models.Usuario usuario);
    }
}