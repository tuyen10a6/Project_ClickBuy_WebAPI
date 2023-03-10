using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<ISanPhamBusiness, SanPhamBus>();
builder.Services.AddTransient<IProductVariantRepository, ProductVariantRepository>();
builder.Services.AddScoped<IProductVariantBusiness, ProductVariantBus>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRespository>();
builder.Services.AddScoped<ICategoriesBusiness, CategoriesBus>();
builder.Services.AddTransient<IBrandRepository, BrandRespository>();
builder.Services.AddScoped<IBrandBusiness, BrandBus>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
