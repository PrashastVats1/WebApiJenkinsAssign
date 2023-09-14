using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJenkinsAssignment.Models;

namespace WebApiJenkinsAssignment.Controllers
{
    [Route("api/Movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "The Lego Movie",
                Genre = "Fantasy, Animation",
                ReleaseYear = 2014,
                Director = "Phil Lord, Chris Miller",
                Actors = "Chris Pratt, Morgan Freeman, Elizabeth Banks"
            },
            new Movie
            {
                Id = 2,
                Title = "John Wick",
                Genre = "Action, Thriller",
                ReleaseYear = 2014,
                Director = "Chad Stahelski",
                Actors = "Keanu Reeves, Michael Nyqvist"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> PutMovie(int id, Movie updatedMovie)
        {
            var existingMovie = movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.ReleaseYear = updatedMovie.ReleaseYear;
            existingMovie.Director = updatedMovie.Director;
            existingMovie.Actors = updatedMovie.Actors;

            return Ok(existingMovie);
        }

        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie newMovie)
        {
            var maxId = movies.Max(m => m.Id);
            newMovie.Id = maxId + 1;

            movies.Add(newMovie);

            return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movieToRemove = movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove == null)
            {
                return NotFound();
            }

            movies.Remove(movieToRemove);

            return NoContent();
        }
    }

}
