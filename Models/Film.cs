using System.ComponentModel.DataAnnotations;

namespace UkwWypozyczalnia.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brak tytułu!")]
        public string Title { get; set; }
        public string Director { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
