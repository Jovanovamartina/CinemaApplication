
using System.ComponentModel.DataAnnotations;


namespace ViewModels
{
    public class MovieProgramViewModel
    {
        public int Id { get; set; }
        public bool ChangeCinemaHall { get; set; }
        public CinemaHallViewModel? CinemaHall { get; set; }
        public int CinemaHallId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Required")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Required")]
        public string EndTime { get; set; }
    }
}
