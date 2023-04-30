

namespace ViewModels
{
    public class SnackOrderViewModel
    {
        public int Id { get; set; }
        public int SnackId { get; set; }
        public SnackViewModel? Snack { get; set; }
        public int SnackQuantity { get; set; }
        public bool Select { get; set; }
        public decimal Price { get; set; }
    }
}
