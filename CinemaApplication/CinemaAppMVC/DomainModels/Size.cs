

namespace DomainModels
{
    public class Size
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public string? Description { get; set; }

        public Size(int seats,string description)
        {
            Seats = seats;
            Description = description;
        }
    }
}
