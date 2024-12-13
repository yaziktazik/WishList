using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore; // Убедитесь, что пространство имен Entity Framework Core добавлено

var builder = WebApplication.CreateBuilder(args);

// Добавление контроллеров
builder.Services.AddControllers();

// Добавление Swagger для документации API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WishlistApp", Version = "v1" });
});

// Добавление DbContext с подключением к базе данных SQL Server
builder.Services.AddDbContext<WishlistAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервисов
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWishListService, WishListService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IWishListItemService, WishListItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IItemTagService, ItemTagService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

var app = builder.Build();

// Настройка конвейера HTTP-запросов
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WishlistApp v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();