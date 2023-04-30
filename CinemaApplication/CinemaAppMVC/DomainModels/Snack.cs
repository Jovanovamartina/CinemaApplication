

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Snack
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
       
        public Snack(string name, decimal price, string image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
    }
}
