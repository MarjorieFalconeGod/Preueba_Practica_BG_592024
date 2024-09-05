using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAPP_20240905_Marjorie_Falcone.Models;

namespace WebAPP_20240905_Marjorie_Falcone.Services.Usuario
{
    public class UsuarioService: IUsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string APIBaseURL;
        private readonly string Controller = "Usuario";

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            APIBaseURL = Environment.GetEnvironmentVariable("APIBaseURL");

        }

        public async Task<List<Models.Usuario>> ConsultarTodos()
        {
            string url = $"{APIBaseURL}/{Controller}";

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        List<Models.Usuario> Usuarios = JsonConvert.DeserializeObject<List<Models.Usuario>>(responseBody);

                        return Usuarios;
                    }
                }
                throw new Exception("Error");
            }
        }

        

        public async Task<Models.Usuario> Actualizar(Models.Usuario usuarios)
        {
            string url = $"{APIBaseURL}/AgeUsuarios";

            string jsonContent = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Usuario usuarioActualizado = JsonConvert.DeserializeObject<Usuario>(responseBody);

                        return usuarioActualizado;
                    }
                }
                throw new Exception("Error al actualizar el usuario.");
            }
        }

        public async Task<Models.Usuario> Crear(Models.Usuario usuarios)
        {
            string url = $"{APIBaseURL}/AgeUsuarios";

            string jsonContent = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Usuario usuarioActualizado = JsonConvert.DeserializeObject<Usuario>(responseBody);

                        return usuarioActualizado;
                    }
                }
                throw new Exception("Error al actualizar el usuario.");
            }
        }



        public async Task<Models.Usuario> ver(int codigo)
        {

            string url = $"{APIBaseURL}/AgeUsuarios/{codigoLicenciatario}/{codigo}";

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Models.Usuario ageUsuario = JsonConvert.DeserializeObject<Models.Usuario>(responseBody);
                        return ageUsuario;
                    }
                }
                return null;
            }
        }

      
    }
}
