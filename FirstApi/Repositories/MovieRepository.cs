using FirstApi.Models;

namespace FirstApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>();
        public List<Movie> GetAll()
        {
            return _movies;
        }
        public int AddNew(Movie pMovie)
        {
            try
            {
                pMovie.Id = new Random().Next();
                _movies.Add(pMovie);
                return pMovie.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }
        public bool UpdateMovie(int pId, Movie pUpdateValues)
        {
            try
            {
                var foundMovie = _movies.Where((m) => { return m.Id == pId; })
                                        .FirstOrDefault();
                //make the updates
                foundMovie.Name = pUpdateValues.Name;
                foundMovie.Producer = pUpdateValues.Producer;
                foundMovie.Cast = pUpdateValues.Cast;
                foundMovie.Director = pUpdateValues.Director;
                foundMovie.Budget = pUpdateValues.Budget;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }
        public bool Delete(int pId)
        {
            //find
            var foundMovie = _movies.Where((m) => { return m.Id == pId; })
                                    .FirstOrDefault();
            _movies.Remove(foundMovie);
            return true;
        }
        public Movie GetSingleMovie(int pId)
        {
            var foundMovie = _movies.Where((m) => { return m.Id == pId; })
                                    .FirstOrDefault();
            return foundMovie;
        }
    }
}
