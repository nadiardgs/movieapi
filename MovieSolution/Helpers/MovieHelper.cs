using MovieSolution.Context;
using MovieSolution.Context.Interfaces;
using MovieSolution.Helpers.Interfaces;
using MovieSolution.Models;
using Newtonsoft.Json;

namespace MovieSolution.Utilitaries
{
    public class MovieHelper : IMovieHelper
    {
        public string GetRatings(List<string> sources, List<string> values)
        {
            var dict = sources.Zip(values, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

            string ratings = string.Empty;

            foreach (KeyValuePair<string, string> entry in dict)
            {
                ratings += $"{entry.Key} {entry.Value};";
            }
            return ratings;
        }

        public Movie OmdbApiSuccessResponseViewModelToMovie(string json, bool watched, string userScore)
        {
            var omdbApiSuccessResponseViewModel = JsonConvert.DeserializeObject<OmdbApiSuccessResponseViewModel>(json);

            var sources = omdbApiSuccessResponseViewModel.Ratings.Select(x => x.Source).ToList();
            var values = omdbApiSuccessResponseViewModel.Ratings.Select(x => x.Value).ToList();

            var ratings = GetRatings(sources, values);

            Movie movie = new()
            {
                IdImbd = omdbApiSuccessResponseViewModel.ImdbId,
                Name = omdbApiSuccessResponseViewModel.Title,
                Description = omdbApiSuccessResponseViewModel.Plot,
                ReleaseDate = omdbApiSuccessResponseViewModel.Released,
                Genre = omdbApiSuccessResponseViewModel.Genre,
                Watched = watched,
                UserScore = userScore,
                Ratings = ratings,
                MetaScore = omdbApiSuccessResponseViewModel.Metascore
            };

            return movie;
        }
    }
}
