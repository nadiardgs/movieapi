using Newtonsoft.Json;

namespace MovieSolution.Models
{
    public partial class OmdbApiFailureResponseViewModel
    {
        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
