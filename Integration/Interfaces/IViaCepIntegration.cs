using ApiCrudTasks.Integration.Response;

namespace ApiCrudTasks.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetViaCep(string cep);
    }
}
