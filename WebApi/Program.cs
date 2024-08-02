using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);


//SignalR için Cors politikasý eklenmesi
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();

    });
});

//SignalR eklenmesi
builder.Services.AddSignalR();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<signalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IDiscountedProductService, DiscountedProductManager>();
builder.Services.AddScoped<IDiscountedProductDal, EfDiscountedProductDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IFooterInfoService, FooterInfoManager>();
builder.Services.AddScoped<IFooterInfoDal, EfFooterInfoDal>();

builder.Services.AddScoped<IOpenHourService, OpenHourManager>();
builder.Services.AddScoped<IOpenHourDal, EfOpenHourDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal >();

builder.Services.AddScoped<IMoneyBoxService, MoneyBoxManager>();
builder.Services.AddScoped<IMoneyBoxDal, EfMoneyBoxDal >();

builder.Services.AddScoped<IRestaurantTableService, RestaurantTableManager>();
builder.Services.AddScoped<IRestaurantTableDal, EfRestaurantTableDal>();

builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IBasketDal, EfBasketDal>();


builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();

builder.Services.AddScoped<IContactFormMessageService, ContactFormMessageManager>();
builder.Services.AddScoped<IContactFormMessageDal, EfContactFormMessageDal>();


//Include metodunde cycle was detected hatasý için;
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Yukarýda tanýmlanan Cors policy nin kullanýmý
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//SignalR için map leme eklenmesi
//normal istek-->  localhost://1234/swagger/category  buna benzerken
//biz þunu da kullanabileceðiz; localhost://1234/signalrhub  --> buraya istekte bulunmamýzý saðlýyor

app.MapHub<SignalRHub>("signalrhub");


app.Run();
