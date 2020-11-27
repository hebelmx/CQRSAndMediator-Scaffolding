using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Projects.Commands;
using Application.Projects.Dtos;
using MediatR;
using Newtonsoft.Json;
using NSwag.Annotations;

namespace WebApplicationApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]")]

    public class Projects : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<Projects> _logger;

        private readonly HttpClient _httpClient;

        public Projects(ILogger<Projects> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [OpenApiOperation("id1", "GetById", "description")]
        [HttpGet("{id}", Name = "GetById")]
        public ProjectDto GetById(int id)
        {
            var result = new ProjectDto()
            { Id = id };

            return result;
        }

        [OpenApiOperation("id2", "GetAllProject", "description")]
        [HttpGet("GetAllProject")]
        public IEnumerable<ProjectDto> GetAllProject(string filter = null)
        {
            var result = (new List<ProjectDto> { new ProjectDto() });

            return result;
        }

        [OpenApiOperation("id3", "GetByName", "description")]
        [HttpGet("GetByName")]
        public ProjectDto GetByName(string name)
        {
            var result = new ProjectDto { Id = 1, Name = name };

            return result;
        }

        [OpenApiOperation("id3", "GetByName", "description")]
        [HttpPost("{id}", Name = "Create")]
        public ProjectDto CreateAsync(ProjectCreateDto createDto)
        {
            var command = new List<ProjectsCreateCommand> { new ProjectsCreateCommand(new ProjectCreateDto()) };

            var result = new ProjectDto { Name = createDto.Name, };

            return result;
        }

        //new domain -c Projects -o Create -ot command -r Response -e Project -p Application
        //new domain -c Projects -o GetById -ot query -r Response -e Project -p Application

        // GET: api/Employee/5

        [NSwag.Annotations.SwaggerResponse((int)HttpStatusCode.OK, typeof(IDictionary<string, ProjectDto>))]
        [NSwag.Annotations.SwaggerResponse((int)HttpStatusCode.OK, typeof(IEnumerable<ProjectDto>))]
        [HttpGet("{id}", Name = "Get")]
        public Task<TResponse> GetAsync<TResponse>(string path)
        {
            _logger.LogInformation($"GET: Retrieving resource of type {typeof(TResponse).Name}");
            return _httpClient.GetFromJsonAsync<TResponse>(path);
        }

        [HttpPost]
        [Produces("application/json", nameof(ProjectDto))]
        public async Task<HttpResponseMessage> PostAsync<TBody>(string path, [FromBody] ProjectCreateDto dto)
        {
            _logger.LogInformation($"POST: Creating resource of type {typeof(TBody).Name}");
            var command = new ProjectsCreateCommand(dto);

            var response = await _mediator.Send(command);

            var result = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response.Data), System.Text.Encoding.UTF8,
                    "application/json")
            };
            return result;
        }

        public Task<HttpResponseMessage> PutAsync<TBody>(string path, TBody body)
        {
            _logger.LogInformation($"PUT: Updating resource of type {typeof(TBody).Name}");
            return _httpClient.PutAsJsonAsync(path, body);
        }

        //[HttpPost]
        //public Task<HttpResponseMessage> DeleteAsync(string path)
        //{
        //    _logger.LogInformation("DELETE: Removing resource");
        //    return _httpClient.DeleteAsync(path);
        ////}

        //[HttpGet]
        //public async Task<Response<ProjectDto>> GetAsync()
        //{
        //    // var response = await _mediator.Send(command);
        //    return default;
        //}
    }
}