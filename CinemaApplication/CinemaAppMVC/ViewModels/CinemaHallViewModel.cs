

using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CinemaHallViewModel
    {
        public int Id { get; set; }
        public MovieViewModel? Movie { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Required")]
        public int MovieId { get; set; }
        public SizeViewModel? Size { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Required")]
        public int SizeId { get; set; }
    }
}
