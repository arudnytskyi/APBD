namespace test2.DTOs;

public class PublishingHouseDto
{
    public int PublishingHouseId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public ICollection<BookDto> Books { get; set; }
}