using Domain.Enums;

namespace Domain.Entities
{
    public partial class ContentCatalog
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public GenreEnum Genre { get; set; }
        public string Language { get; set; } = null!;
        public string CountryOfOrigin { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Rating { get; set; }
        public string? Synopsis { get; set; }
        public string? Cast { get; set; }
        public string? Director { get; set; }
        public string? ProductionCompany { get; set; }
        public string? PostUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
