using ApiCrudTasks.Integration.Response;
using Refit;

namespace ApiCrudTasks.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ViaCepResponse>> GetViaCep(string cep);
    }
}
