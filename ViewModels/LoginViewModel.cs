using System.ComponentModel.DataAnnotations;

namespace UkwWypozyczalnia.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Wprowadź login")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Wprowadź hasło")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
