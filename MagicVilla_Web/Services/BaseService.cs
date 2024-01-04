using MagicVilla_Ultility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace MagicVilla_Web.Services
{
	public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MagicAPI");

                HttpRequestMessage requestMessage = new();
                requestMessage.Headers.Add("Accept", "application/json");
                requestMessage.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    requestMessage.Content = new StringContent(
						JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,
                        "application/json"
                    );
                }
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        requestMessage.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        requestMessage.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        requestMessage.Method = HttpMethod.Delete;
                        break;
                    default:
                        requestMessage.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage responseMessage = null;
                responseMessage = await client.SendAsync(requestMessage);

                var apiContent = await responseMessage.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;
            }
        }
    }
}
