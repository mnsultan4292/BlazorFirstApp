using BlazorFirstApp.Shared.Models;
using BlazorFirstApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorFirstApp.Server.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _db;
        public BookRepository(BookDBContext db)
        {
            _db = db;
        }

        public async Task<List<MasterBook>> GetBooks()
        {
            if (_db != null)
                return await _db.MasterBooks.ToListAsync();
            return null;
        }

        public async Task<MasterBook> GetBookById(int id)
        {
            if (_db != null)
                return await _db.MasterBooks.FirstOrDefaultAsync(x => x.BookId == id);
            return null;
        }

        public async Task<int> PostBooks(MasterBook masterBook)
        {
            if (_db != null)
            { 
                _db.MasterBooks.Add(masterBook);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> UpdateBook(MasterBook masterBook)
        {
            if (_db != null)
            {
                _db.MasterBooks.Update(masterBook);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> DeleteBook(int id)
        {
            if (_db != null)
            {
                var data =await _db.MasterBooks.FirstOrDefaultAsync(x => x.BookId == id);
                if (data != null)
                {
                    _db.MasterBooks.Remove(data);
                    return await _db.SaveChangesAsync();
                }
            }
            return 0;
        }
    }
}
