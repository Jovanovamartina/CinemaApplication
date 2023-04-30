


namespace DomainModels
{
    public class Reservation
    {
       
        public int Id { get; set; }
        public MovieProgram MovieProgram { get; set; }
        public int MovieProgramId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<SnackOrder> SnackOrders { get; set; }
        public int TicketQuantity { get; set; }
        public decimal FullPrice { get; set; }
        public decimal SnackPrice { get; set; }
        public decimal TicketPrice { get; set; }
        public Reservation()
        {

        }
        public Reservation(int id,int movieProgramId,string name,string lastName,/*ICollection<SnackOrder>snackOrders,*/int ticketQuantity,decimal fullPrice)
        {
            Id = id;
            MovieProgramId = movieProgramId;
            Name = name;
            LastName = lastName;
            //SnackOrders = snackOrders;
            TicketQuantity = ticketQuantity;
            FullPrice = fullPrice;
        }
    }
}
