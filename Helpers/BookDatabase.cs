using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBRAppMobile.Models;

public class BookDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public BookDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Book>().Wait();
    }

    public Task<List<Book>> GetBooksAsync() =>
        _database.Table<Book>().ToListAsync();

    public Task<Book> GetBookAsync(int id) =>
        _database.Table<Book>().FirstOrDefaultAsync(b => b.Id == id);

    public Task<int> SaveBookAsync(Book book) =>
        _database.InsertOrReplaceAsync(book);

    public Task<int> DeleteBookAsync(Book book) =>
        _database.DeleteAsync(book);
}
