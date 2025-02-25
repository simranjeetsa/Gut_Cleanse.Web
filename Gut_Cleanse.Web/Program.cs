using Gut_Cleanse.Data;
using Gut_Cleanse.Repo.BlogsRepo;
using Gut_Cleanse.Repo.Common;
using Gut_Cleanse.Repo.PaymentRepo;
using Gut_Cleanse.Repo.ProgramsRepo;
using Gut_Cleanse.Repo.User;
using Gut_Cleanse.Service.BlogsService;
using Gut_Cleanse.Service.CommonService;
using Gut_Cleanse.Service.PaymentService;
using Gut_Cleanse.Service.ProgramsService;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommonRepo, CommonRepo>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProgramsRepo, ProgramsRepo>();
builder.Services.AddScoped<IProgramsServices, ProgramsServices>();
builder.Services.AddScoped<IBlogsRepo, BlogsRepo>();
builder.Services.AddScoped<IBlogsService, BlogsService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 40))));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
