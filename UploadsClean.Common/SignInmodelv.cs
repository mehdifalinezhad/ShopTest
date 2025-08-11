using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Common
{
	public class SignInmodelv
	{
		[Required(ErrorMessage = "این نباید خالی باشه ")]
		public string Username { get; set; }

	 [Required(ErrorMessage = "این نباید خالی باشه")]
		public string Password { get; set; }
	}
}
