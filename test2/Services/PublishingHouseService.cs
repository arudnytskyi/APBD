using test2.Data;
using test2.DTOs;

namespace test2.Services;

public interface IPublishingHouseService
{
    IEnumerable<PublishingHouseDto> GetPublishingHouses(string city, string country);
}

public class PublishingHouseService : IPublishingHouseService
{
    private readonly AppDbContext _context;

    public PublishingHouseService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<PublishingHouseDto> GetPublishingHouses(string city, string country)
    {
        var query = _context.PublishingHouses.AsQueryable();

        if (!string.IsNullOrEmpty(city))
        {
            query = query.Where(ph => ph.City == city);
        }

        if (!string.IsNullOrEmpty(country))
        {
            query = query.Where(ph => ph.Country == country);
        }

        return query
            .OrderBy(ph => ph.Country)
            .ThenBy(ph => ph.Name)
            .Select(ph => new PublishingHouseDto
            {
                PublishingHouseId = ph.PublishingHouseId,
                Name = ph.Name,
                City = ph.City,
                Country = ph.Country,
                Books = ph.Books.Select(b => new BookDto
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Genres = b.Genres.Select(g => new GenreDto
                    {
                        GenreId = g.GenreId,
                        Name = g.Name
                    }).ToList(),
                    Authors = b.Authors.Select(a => new AuthorDto
                    {
                        AuthorId = a.AuthorId,
                        Name = a.Name
                    }).ToList()
                }).ToList()
            }).ToList();
    }
}