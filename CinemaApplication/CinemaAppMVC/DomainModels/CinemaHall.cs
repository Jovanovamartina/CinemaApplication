

namespace DomainModels
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public CinemaHall(int movieId,int sizeId)
        {
            MovieId = movieId;
            SizeId = sizeId;
        }

        public CinemaHall()
        {
        }
    }
}
