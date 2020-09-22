using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet("ListAll")]
        public List<Movie> List()
        {
            List<Movie> movielist = Movie.GetMovies();
            return movielist;
        }

        [HttpGet("ListCategory")]
        public List<Movie> ListCategory(string category)
        {
            List<Movie> movielist = Movie.GetMoviesCat(category);
            if (movielist.Count < 1)
            {
                return new List<Movie>();
            }
            else
            {
                return movielist;
            }           
        }

        [HttpGet("Random")]
        public Movie Random()
        {
            List<Movie> movielist = Movie.GetMovies();
            Movie movie = Movie.GetRandom(movielist);
            return movie;
        }

        [HttpGet("Random/{category}")]
        public Movie RandomCategory(string category)
        {
            List<Movie> movielist = Movie.GetMoviesCat(category);
            if (movielist.Count < 1)
            {
                return new Movie();
            }
            else
            {
                Movie movie = Movie.GetRandom(movielist);
                return movie;
            }
        }







    }
}
