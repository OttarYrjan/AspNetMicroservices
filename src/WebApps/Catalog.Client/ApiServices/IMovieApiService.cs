using Movies.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Product>> GetMovies();
        Task<Product> GetMovie(string id);
        Task<Product> CreateMovie(Product movie);
        Task<Product> UpdateMovie(Product movie);
        Task DeleteMovie(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
