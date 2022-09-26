using DVDCatalog.DAOs;
using DVDCatalog.Repositories;
namespace DVDCatalog.Workers
{
    public class Movie
    {
        MovieRepo repo;

        public Movie()
        {
            repo = new MovieRepo();
        }
    
        public List<MovieDAO> GetAllMovies()
        {
           
            return repo.GetAllMovies();
        }
    
        public bool AddNewMovie(MovieDAO movie)
        {
            return repo.AddNewMovie(movie);
        }

        public MovieDAO MovieSearch(string title)
        {
            return repo.MovieSearch(title);
        }

        public bool DeleteMovie(string title)
        {
            return repo.DeleteMovie(title);
        }
    }
}
