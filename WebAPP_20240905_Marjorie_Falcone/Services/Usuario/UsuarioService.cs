using Microsoft.AspNetCore.Mvc;
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
            APIBaseURL = "https://localhost:44362";
            //APIBaseURL = Environment.GetEnvironmentVariable("APIBaseURL");


        }

        public async Task<List<Models.Usuario>> ConsultarTodos()
        {
            string url = $"{APIBaseURL}/{Controller}";

            //using (var httpClient = new HttpClient())
            //{
            //    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //    HttpResponseMessage response = await httpClient.GetAsync(url);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        if (response.Content != null)
            //        {
            //            string responseBody = await response.Content.ReadAsStringAsync();

            //            List<Models.Usuario> Usuarios = JsonConvert.DeserializeObject<List<Models.Usuario>>(responseBody);

            //            return Usuarios;
            //        }
            //    }
            //    throw new Exception("Error");
            //}

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Models.Usuario> usuarios = JsonConvert.DeserializeObject<List<Models.Usuario>>(responseBody);
                return usuarios;
            }

            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");

        }



        public async Task<Models.Usuario> Actualizar(Models.Usuario usuarios)
        {
            string url = $"{APIBaseURL}/{Controller}";

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
                        Models.Usuario usuarioActualizado = JsonConvert.DeserializeObject<Models.Usuario>(responseBody);

                        return usuarioActualizado;
                    }
                }
                throw new Exception("Error al actualizar el usuario.");
            }
        }

        



        public async Task<Models.Usuario> ver(int codigo)
        {

            string url = $"{APIBaseURL}/{Controller}/{codigo}";

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

        public async Task<Models.Usuario> Crear(Models.Usuario usuario)
        {
            string url = $"{APIBaseURL}/{Controller}";

            string jsonContent = JsonConvert.SerializeObject(usuario);
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
                        Models.Usuario usuarioActualizado = JsonConvert.DeserializeObject<Models.Usuario>(responseBody);

                        return usuarioActualizado;
                    }
                }
                throw new Exception("Error al actualizar el usuario.");
            }
        }
    }
}
