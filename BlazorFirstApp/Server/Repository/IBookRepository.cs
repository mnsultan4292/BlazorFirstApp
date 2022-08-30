using BlazorFirstApp.Shared.Models;

namespace BlazorFirstApp.Server.Repository
{
    public interface IBookRepository
    {
        Task<List<MasterBook>> GetBooks();
        Task<MasterBook> GetBookById(int id);

        Task<int> PostBooks(MasterBook masterBook);
        Task<int> DeleteBook(int id);
        Task<int> UpdateBook(MasterBook masterBook);

    }
}
