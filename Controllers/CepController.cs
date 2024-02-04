using ApiCrudTasks.Integration.Interfaces;
using ApiCrudTasks.Integration.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;

        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> GetDataAddress(string cep)
        {
            var responseData = await _viaCepIntegration.GetViaCep(cep);
            if (responseData == null)
            {
                return BadRequest("Cep not found!");
            }

            return Ok(responseData);
        }
    }
}
