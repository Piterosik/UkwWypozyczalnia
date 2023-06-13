using System.ComponentModel.DataAnnotations;

namespace UkwWypozyczalnia.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Wprowadź email")]
		[EmailAddress(ErrorMessage = "Nieprawidłowy format email")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Wprowadź hasło")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Powtórz hasło")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Hasła muszą być jednakowe!")]
		public string ConfirmPassword { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
