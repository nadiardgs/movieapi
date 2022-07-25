namespace MovieSolution.Context.Interfaces
{
    public interface IOmdbApiContext
    {
        bool IsImdbIdInvalidAsync(string json);
        Task<string> GetMovieApiResponseFromImdbId(string imdbId);
    }
}
