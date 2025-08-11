using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Common
{
	public class UserModel
	{
		[Required(ErrorMessage = "نام الزامی است")]
		public string FarsiFirstName { set; get; }
		[Required(ErrorMessage = "نام خانوادگی الزامی است ")]
		public string FarsiLastName { get; set; }
		[Required(ErrorMessage = "نام کاربری الزامی است ")]
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		[Required(ErrorMessage = "ورود رمز عبور اجباری است ")]
		public string Password { get; set; }
		[Required(ErrorMessage = "ورود  تکرار رمز عبور اجباری است ")]
		[Compare("Password", ErrorMessage = "تکرار رمز عبور باید شبیه رمز عبور باشد")]
		public string ComfirmPassword { get; set; }
		public string Role { get; set; }

	}
}
