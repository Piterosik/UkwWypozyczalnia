using System.Collections.Generic;
using UkwWypozyczalnia.Models;

namespace UkwWypozyczalnia.ViewModels
{
    public class AddFilmViewModel
    {
        public Film Film { get; set; }
        public List<Category> Categories { get; set; }
    }
}
