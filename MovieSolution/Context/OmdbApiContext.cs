using MovieSolution.Context.Interfaces;
using MovieSolution.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MovieSolution.Context
{
    public class OmdbApiContext : IOmdbApiContext
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string OmdbUrl = "http://www.omdbapi.com";
        private readonly string OmdbKey = "46065334";

        public OmdbApiContext(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public bool IsImdbIdInvalidAsync(string json)
        {
            bool success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };
            var result = JsonConvert.DeserializeObject<OmdbApiFailureResponseViewModel>(json, settings);

            return success;
        }

        public async Task<string> GetMovieApiResponseFromImdbId(string imdbId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                OmdbUrl);

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpResponseMessage = await httpClient.GetAsync
                ($"{OmdbUrl}?apikey={OmdbKey}&i={imdbId}").ConfigureAwait(false);

            var json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            return json;
        }
    }
}
