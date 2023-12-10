using Microsoft.EntityFrameworkCore;
using web_library;
using web_library.Book.DataProvider;
using web_library.Book.Repository;
using web_library.Book.Service;
using web_library.Genre.Repository;
using web_library.Genre.Service;
using web_library.User.Repository;
using web_library.User.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"))
);

builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.ControllersOptions();
builder.Services.AddHttpContextAccessor();
builder.Services.ServicesInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();