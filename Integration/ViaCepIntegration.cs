using ApiCrudTasks.Integration.Interfaces;
using ApiCrudTasks.Integration.Refit;
using ApiCrudTasks.Integration.Response;

namespace ApiCrudTasks.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {

        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit) 
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> GetViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.GetViaCep(cep);
            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
