using EndPoint.Admin.Authorization.ClaimBasedAuthorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NToastNotify;
using System.Text;
using UploadsClean.Domain.Entities.Users;
using UploadsClean.Persistence.DataBaceContext;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllersWithViews();
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = new PathString("/ManageUser/Login");
        options.Cookie.SameSite = SameSiteMode.Unspecified;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20.0);
        options.AccessDeniedPath = new PathString("/ManageUser/Login");
        options.LogoutPath = new PathString("/ManageUser/Login");
        options.SlidingExpiration = true;

        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    });


    builder.Services.AddMvc().AddNToastNotifyNoty(new NotyOptions() 
    {
        Timeout = 3000,
        ProgressBar = true,
        Modal = true,
        Layout = "topCenter",
        Theme = "metroui"
    });
    builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
    //builder.Services.AddSingleton<IAuthorizationHandler, ClaimHandler>();


    builder.Services.AddDbContext<AppDbContext>();

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddDefaultTokenProviders()
                 .AddEntityFrameworkStores<AppDbContext>();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = false;

        // User settings.
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = false;
    });
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(key)
	};
});
var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    //use middleware
    app.UseHttpsRedirection();
    app.UseStaticFiles();
app.UseSession();
app.UseRouting();

    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.Run();







