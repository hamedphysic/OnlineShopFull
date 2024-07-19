using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onlineshop.EFCore;
using OnlineShopBackOfficeApplication.Services.Contracts;
using OnlineShopBackOfficeApplication.Services.SaleServices;
using OnlineShopBackOfficeApplication.Services.UserManagmentServices;
using OnlineshopDmain.Aggregates.UserManagment;
using Onlineshope.RepositoryDesignPttern.Contracts;
using Onlineshope.RepositoryDesignPttern.Services.Sale;
using OnlineShopOfficeApplication.Services.Contracts;
using OnlineShopOfficeApplication.Services.SaleService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ------------------- SQL Connection ----------------------------------
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<OnlineshopDbContext>(x=> x.UseSqlServer(connectionString));



// ---------- Identity -----------------------------------------------------------
builder.Services.AddIdentity<OnlineShopUser, OnlineShopRole>().AddEntityFrameworkStores<OnlineshopDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();



// ---------  Repository --------------------------------------------
//builder.Services.AddScoped<IRepository<Product, Guid>, ProductRepository>();
//builder.Services.AddScoped<IRepository<ProductCategory, int>, ProductCategoryRepository>();
builder.Services.AddScoped<IProductRepository , ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository , ProductCategoryRepository>();
builder.Services.AddScoped<IOrderRepository , OrderRepository>();



// ---------- Services ------------------------------------------------
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IOrderServiceBackOffice, OrderServiceBackOffice>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
