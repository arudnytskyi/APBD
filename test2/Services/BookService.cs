using test2.Data;
using test2.DTOs;
using test2.Models;

namespace test2.Services;

public interface IBookService
{
    (bool Success, string Message, BookDto Book) AddBook(CreateBookDto newBook);
}

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public (bool Success, string Message, BookDto Book) AddBook(CreateBookDto newBook)
    {
        var publishingHouse = _context.PublishingHouses.Find(newBook.PublishingHouseId);
        if (publishingHouse == null)
        {
            return (false, "Publishing house not found", null);
        }

        var authors = _context.Authors.Where(a => newBook.AuthorIds.Contains(a.AuthorId)).ToList();
        if (authors.Count != newBook.AuthorIds.Count)
        {
            return (false, "One or more authors not found", null);
        }

        var genres = new List<Genre>();
        foreach (var genreDto in newBook.Genres)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Name == genreDto.Name);
            if (genre == null)
            {
                genre = new Genre { Name = genreDto.Name };
                _context.Genres.Add(genre);
            }
            genres.Add(genre);
        }

        var book = new Book
        {
            Title = newBook.Title,
            PublishingHouse = publishingHouse,
            Authors = authors,
            Genres = genres
        };

        _context.Books.Add(book);
        _context.SaveChanges();

        var bookDto = new BookDto
        {
            BookId = book.BookId,
            Title = book.Title,
            Authors = authors.Select(a => new AuthorDto { AuthorId = a.AuthorId, Name = a.Name }).ToList(),
            Genres = genres.Select(g => new GenreDto { GenreId = g.GenreId, Name = g.Name }).ToList()
        };

        return (true, null, bookDto);
    }
}