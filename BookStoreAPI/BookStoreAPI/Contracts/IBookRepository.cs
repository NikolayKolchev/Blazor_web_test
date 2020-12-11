using BookStoreAPI.Data;
using System.Threading.Tasks;

namespace BookStoreAPI.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        public Task<string> GetImageFileName(int id);
    }
}
