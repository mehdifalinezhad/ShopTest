using EndPoint.Admin.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using NToastNotify;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UploadsClean.Common;
using UploadsClean.Common.Dto;
using UploadsClean.Domain.Entities.Users;

namespace EndPoint.Admin.Controllers
{
	public class ManageUserController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IToastNotification notishow;
		private readonly IConfiguration _config;

		public ManageUserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IToastNotification notishow, SignInManager<ApplicationUser> signInManager, IConfiguration config)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			this.notishow = notishow;
			_signInManager = signInManager;
			_config = config;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AddUser()
		{

			return  View(new UserDto());

		}
		[HttpPost]
		public async Task<IActionResult> AddUser(UserDto UsertoAdd)
		{
			ApplicationUser user = DtoToModel.UserModelToDto(UsertoAdd);

			var userModel = await _userManager.FindByNameAsync(user.FarsiFirstName);
			if (userModel == null)
			{
				var result = await _userManager.CreateAsync(user, user.Password);
				var ThisRole = await _userManager.AddToRoleAsync(user, user.Role);
				ModelState.Clear();
				notishow.AddSuccessToastMessage("کاربر اضاف شد");
			}
			else 
			{
				notishow.AddSuccessToastMessage("شما قبلا ثبت نام کردین برو لاگین");
			}
		
			
			
			return View(UsertoAdd);
	
		}
		
		public async Task<IActionResult> Login()
		{


			return View(new signInDto());

		}

		[HttpPost]
		public async Task<IActionResult> Login(signInDto sign)
		{
			if (!ModelState.IsValid)
			{
				return View(sign); ;
			}
			var signUser = await _userManager.FindByNameAsync(sign.Username);

			if (signUser == null)
			{
				notishow.AddErrorToastMessage("شما اول باید ثبت نام کنید");

				return RedirectToAction(nameof(AddUser));
			}
			ApplicationUser _user = DtoToModel.UserSignInModelToDto(sign);
			var checkOut = _signInManager.PasswordSignInAsync(_user, _user.Password, true, true);
			var token = GenerateJwtToken(signUser);
            string Token = await _userManager.GeneratePasswordResetTokenAsync(signUser);

            //this Optional
            ActiveUser activeUser = new ActiveUser()
			{
				UserId = signUser.Id

			};
			CurrentUser.Set(activeUser);
			notishow.AddSuccessToastMessage("ورود با موفقیت انجام شد");
			return RedirectToAction("Index","Home"); ;

		}
	
		private string GenerateJwtToken(ApplicationUser user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim("userid", user.Id.ToString())
		    };

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(2),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		//پروفایل
		public IActionResult EditUser()
		{
			 string UserId = CurrentUser.Get();
			if(UserId == null) 
			{
                notishow.AddErrorToastMessage("هنوز لاگین نکردی");
				return RedirectToAction("Index", "Home");
            }
		     var signUser = _userManager.Users.Where(c=>c.Id==UserId).FirstOrDefault();
			UserDto userDto = ModelToDto.AboutEditUser(signUser);


			 return View(userDto);
		}
		[HttpPost]
		public async Task<IActionResult> EditUser(UserDto userDto)
		{
			var userBefore= _userManager.Users.Where(c => c.Id == userDto.Id).FirstOrDefault();
			 userBefore.PhoneNumber=userDto.PhoneNumber;
			 userBefore.UserName=userDto.UserName;
			 userBefore.Email=userDto.Email;
			 userBefore.Password=userDto.Password;
			 userBefore.Role=userDto.Role;
			 userBefore.UserName =userDto.UserName;
			 userBefore.FarsiFirstName=userDto.FarsiFirstName;
			 userBefore.FarsiLastName=userDto.FarsiLastName;
			 

			var UserUpdated =await _userManager.UpdateAsync(userBefore);
			notishow.AddSuccessToastMessage("کاربر ویرایش شد");

			return View(userDto);
		}
	

	}
}