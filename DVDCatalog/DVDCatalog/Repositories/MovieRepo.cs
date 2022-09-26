using Dapper;
using System.Data.SqlClient;
using DVDCatalog.DAOs;
namespace DVDCatalog.Repositories

{
    public class MovieRepo
    {
        private const string connectionString = @"Data Source=DESKTOP-M0I0HA2;Initial Catalog=MovieCatalogDatabase;Integrated Security=True";

        public List<MovieDAO> GetAllMovies()
        {
            List<MovieDAO> movies = new List<MovieDAO>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                movies = connection.Query<dynamic>("SELECT * FROM Movie").Select(movie =>
                new MovieDAO(movie.Title, movie.Description, movie.Genre, movie.Director, movie.DateReleased, movie.MovieStar, movie.Rating)).ToList();
            }
           
            return movies;
        }

        public bool AddNewMovie(MovieDAO movie)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@$"INSERT INTO Movie (Title, Description, Genre, Director, DateReleased, Rating, MovieStar)
                                          VALUES('{movie.Title}','{movie.Description}','{movie.Genre}','{movie.Director}','{movie.DateReleased}',{movie.Rating},'{movie.MovieStar}')");
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    
        public MovieDAO MovieSearch(string title)
        {
            MovieDAO movie = new MovieDAO();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                movie = connection.QuerySingleOrDefault<MovieDAO>(@$"SELECT * FROM Movie WHERE Title = '{title}'");
            }
            return movie;
        }

        public bool DeleteMovie(string title)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@$"DELETE Movie WHERE Title = '{title}'");
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
