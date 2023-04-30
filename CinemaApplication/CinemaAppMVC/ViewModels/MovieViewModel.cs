
using System.ComponentModel.DataAnnotations;


namespace ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime YearReleased { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Required")]
        public int Duration { get; set; }
        [Required]
        public string? Image { get; set; }
    }
}
