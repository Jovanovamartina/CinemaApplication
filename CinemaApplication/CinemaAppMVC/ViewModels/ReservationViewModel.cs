

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int SnackOrderId { get; set; }
        [DisplayName("Full Price")]
        public decimal FullPrice { get; set; }
        public int MovieProgramId { get; set; }
        public MovieProgramViewModel? MovieProgram { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int TicketQuantity { get; set; }
        public decimal SnackPrice { get; set; }
        public decimal TicketPrice { get; set; }
        public List<SnackOrderViewModel>? SnackOrders { get; set; }
    }
}
