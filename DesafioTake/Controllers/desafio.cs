using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DesafioTake.Repositories;
using System.Text.Json;

namespace DesafioTake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class desafio : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// Método que se comunica com a Api do GitHub para retornar a lista de repositórios da TakeBlip
        /// </summary>
        /// <param name="id">Em ordem crescente de data de criação e a partir do índice 0, qual repositório o usuário deseja retornar</param>
        /// <returns>Retorna os seguintes dados do repositório: nome, descrição, avatar e data de criação</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Obter([FromRoute] int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "rafaelcmorais02");
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/takenet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<MyData>>(await streamTask);
            var jsonString = repositories[id];
            return Ok(jsonString);
        }
    }
}
