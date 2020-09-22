using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace RestAPI
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }


        public static List<Movie> GetMovies()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Movie;user id=dbuser;password=abc123");
            List<Movie> movielist = db.GetAll<Movie>().ToList();
            return movielist;
        }

        public static List<Movie> GetMoviesCat(string category)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Movie;user id=dbuser;password=abc123");
            List<Movie> movielist = db.Query<Movie>($"SELECT * FROM Movies WHERE Category='{category}'").AsList();
            return movielist;
        }

        public static Movie GetRandom(List<Movie> movielist)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Movie;user id=dbuser;password=abc123");
            int movietotal = movielist.Count;
            Random random = new Random();
            Movie movie = movielist[random.Next(1, movietotal)];
            return movie;
        }

    }
}
