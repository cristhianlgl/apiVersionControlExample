using ApiVersionControl.DTO;
using ApiVersionControl.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiVersionControl.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiTestSettings _apiTestSettings;
        private readonly HttpClient _httpClient;
        public UsersController(ApiTestSettings apiTestSettings, HttpClient httpClient)
        {
            _apiTestSettings = apiTestSettings;
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetUserData")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", _apiTestSettings.ApiId);

            var response = await _httpClient.GetStreamAsync(_apiTestSettings.ApiUrl);
            var data = await JsonSerializer.DeserializeAsync<UserResponseData>(response);
            var user = data?.Data;

            return Ok(user);
        }
    }
}
