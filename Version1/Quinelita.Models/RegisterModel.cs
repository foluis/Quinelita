using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quinelita.Models
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "Have to supply an e-mail address")]
		public string Email { get; set; }

		//[Required(ErrorMessage = "Have to supply a password")]
		//public string Clave { get; set; }

		//[Compare("Clave", ErrorMessage = "The repeat password did not seem correct")]
		//public string ConfirmacionClave { get; set; }
	}
}
