using BusinessLayer.CustomServices.Abstract;
using BusinessLayer.CustomServices.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


builder.Services.AddDbContext<signalRContext>(); //for Identity configuration

builder.Services.AddIdentity<CustomUser, CustomRole>().AddEntityFrameworkStores<signalRContext>();  //for Identity configuration

builder.Services.AddScoped<IFileUploadService, FileUploadService>();

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();  //Authorize için tanýmlama

builder.Services.AddControllersWithViews(opt =>  
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));  //Tüm isteklerde authanticate filter ekledik, her sayfa için login gerekli oldu. builder.Services.AddControllersWithViews() þeklindeydi, parametre ekledik.
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	options.AccessDeniedPath = "/Error/ErrorPage/";
	options.LoginPath = "/Login/Index";
});



builder.Services.AddHttpClient(); //HttpClient istekleri için eklendi




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/ErrorPage/");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();  //Authenticaton için ekledik

app.UseAuthorization();

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    if (response.StatusCode != 200)
    {
        response.Redirect("/Error/ErrorPage");
    }
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RestaurantTable}/{action=TablesRealtime}/{id?}");
    //pattern: "{controller=Basket}/{action=Index}/{id=4}");

app.Run();
