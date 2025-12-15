using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        protected readonly HttpClient _client;

        public ApiControllerBase(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("ScuolaApi");
        }
    }

}
