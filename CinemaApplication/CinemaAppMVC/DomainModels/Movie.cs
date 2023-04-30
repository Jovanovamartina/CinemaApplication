using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Duration { get; set; }
        public DateTime YearReleased { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public Movie(string title,string genre,int duration,DateTime yearReleased,string image)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
            YearReleased = yearReleased;
            Image = image;
        }
    }
}
