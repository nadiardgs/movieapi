using MovieSolution.Context;

namespace MovieSolution.Helpers.Interfaces
{
    public interface IMovieHelper
    {
        Movie OmdbApiSuccessResponseViewModelToMovie(string json, bool watched, string userScore);
    }
}
