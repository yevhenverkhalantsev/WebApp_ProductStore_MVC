using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using oblig1_Yevhen_Verkhalantsev.EntityFramework;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();

services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=ProductRegister.db"));

services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

services.AddTransient<IProductService, ProductService>();
services.AddTransient<IProducerService, ProducerService>();
services.AddTransient<ICategoryService, CategoryService>();

services.AddFluentValidationAutoValidation();
services.AddScoped<IValidator<CreateCategoryHttpPostModel>, CreateCategoryHttpPostValidator>();
services.AddScoped<IValidator<CreateProductHttpPostModel>, CreateProductHttpPostValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Create}/{id?}");

app.Run();