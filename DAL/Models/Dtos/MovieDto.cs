namespace Movies.DAL.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public string? Description { get; set; }
        public required string Clasification { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
