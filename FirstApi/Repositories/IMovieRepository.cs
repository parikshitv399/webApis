using FirstApi.Models;

namespace FirstApi.Repositories
{
    public interface IMovieRepository
    {
        int AddNew(Movie pMovie);
        bool Delete(int pId);
        List<Movie> GetAll();
        Movie GetSingleMovie(int pId);
        bool UpdateMovie(int pId, Movie pUpdateValues);
    }
}