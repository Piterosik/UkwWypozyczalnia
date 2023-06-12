using System.Collections.Generic;

namespace UkwWypozyczalnia.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
