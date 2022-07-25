using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSolution.Context;
using MovieSolution.Context.Interfaces;
using MovieSolution.Helpers.Interfaces;
using System.Data;
using System.Net;

namespace MovieSolution.Controllers
{
    [ApiController]
    [Route("/movies")]
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly IOmdbApiContext _omdbApiContext;
        private readonly IMovieHelper _movieHelper;

        public MoviesController(MovieDbContext context, IOmdbApiContext omdbApiContext, IMovieHelper movieHelper)
        {
            _context = context;
            _omdbApiContext = omdbApiContext;
            _movieHelper = movieHelper;
        }

        /// <summary>
        /// Returns all of the movies.
        /// </summary>
        /// <returns>Movie list</returns>
        [HttpGet("/all")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
              return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Returns a movie by its IMDB id.
        /// </summary>
        /// <returns>Movie list</returns>
        [HttpGet("/{idImdb}")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<ActionResult<Movie>> GetById(string idImdb)
        {
            var movieFound = _context.Movies
                            .Where(m => m.IdImbd == idImdb)
                            .FirstOrDefault();


            return movieFound == null ? NotFound($"Movie {idImdb} doesn't exist!") :
                    Ok(movieFound);
        }

        /// <summary>
        /// Adds a new movie.
        /// </summary>
        /// <returns>Movie list</returns>
        [HttpPost("/new")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        [ProducesResponseType(((int)HttpStatusCode.BadRequest))]
        public async Task<ActionResult<Movie>> Insert(string idImdb, bool watched, string userScore)
        {
            var movieFound = _context.Movies
                            .Where(m => m.IdImbd == idImdb)
                            .FirstOrDefault();

            if (movieFound != null)
            {
                return BadRequest($"Movie {movieFound.Name} already added!");
            }

            var json = await _omdbApiContext.GetMovieApiResponseFromImdbId(idImdb);

            var invalididImdb = _omdbApiContext.IsImdbIdInvalidAsync(json);
            if (invalididImdb)
                return NotFound($"Movie {idImdb} doesn't exist on IMDB!");

            var omdbApiResult = _movieHelper.OmdbApiSuccessResponseViewModelToMovie(json, watched, userScore);

            _context.Movies.Add(omdbApiResult);
            await _context.SaveChangesAsync();
            return Ok(omdbApiResult);
        }

        /// <summary>
        /// Edits a movie.
        /// </summary>
        /// <returns>Movie list</returns>
        [HttpPost("/edit/{idImdb}")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<ActionResult> Edit(string idImdb, string? name, string? description, bool watched, string? userScore)
        {
            
            var movie = _context.Movies
                            .Where(m => m.IdImbd == idImdb)
                            .FirstOrDefault();

            if (movie != null)
            {
                movie.Name = !string.IsNullOrEmpty(name) ? name : movie.Name;
                movie.Description = !string.IsNullOrEmpty(description) ? description : movie.Description;
                movie.Watched = watched;
                movie.UserScore = !string.IsNullOrEmpty(userScore) ? userScore : movie.UserScore;

                _context.Update(movie);
                await _context.SaveChangesAsync();
                return Ok(movie);
            }
            else
            {
                return NotFound($"Movie {idImdb} doesn't exist!");
            }

        }

        /// <summary>
        /// Removes a movie.
        /// </summary>
        /// /// <returns>Movie list</returns>
        [HttpPost("/delete/{idImdb}")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<ActionResult<Movie>> Delete(string idImdb)
        {
            var movie = _context.Movies
                            .Where(m => m.IdImbd == idImdb)
                            .FirstOrDefault();

            if (movie != null)
            {
                string movieName = movie.Name;
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return Ok($"Movie {movieName}, idImdb {idImdb}: deleted successfully.");
            }
            else
            {
                return NotFound($"Movie {idImdb} doesn't exist!");
            }   
        }
    }
}
