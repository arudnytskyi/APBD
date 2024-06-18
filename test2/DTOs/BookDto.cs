namespace test2.DTOs;

public class BookDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public ICollection<GenreDto> Genres { get; set; }
    public ICollection<AuthorDto> Authors { get; set; }
}