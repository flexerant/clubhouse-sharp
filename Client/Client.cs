using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Flexerant.ClubhouseSharp
{
    public class Client : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _enpointUrl;
        private readonly string _apiToken;

        public Client(string apiToken) : this(apiToken, null)
        { }

        public Client(string apiToken, HttpMessageHandler httpMessageHandler)
        {
            _apiToken = apiToken;

            if (httpMessageHandler == null)
            {
                _httpClient = new HttpClient();
            }
            else
            {
                _httpClient = new HttpClient(httpMessageHandler);
            }
        }

        public async Task<CreateStoryResponse> CreateStoryAsync(CreateStoryRequest request)
        {
            string uriWithApiToken = $"https://api.clubhouse.io/api/v3/{request.Path}?token={_apiToken}";
            string content = request.Serialize();
            CreateStoryResponse storyResponse = new CreateStoryResponse();

            using (HttpContent httpContent = new StringContent(content))
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (HttpResponseMessage response = await _httpClient.PostAsync(uriWithApiToken, httpContent))
                {
                    storyResponse.JsonObject =  await response.DeserializeAsync<CreateStoryResponse>();
                }
            }

            return storyResponse;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
