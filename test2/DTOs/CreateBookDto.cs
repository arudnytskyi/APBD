namespace test2.DTOs;

public class CreateBookDto
{
    public string Title { get; set; }
    public int PublishingHouseId { get; set; }
    public ICollection<int> AuthorIds { get; set; }
    public ICollection<GenreDto> Genres { get; set; }
}