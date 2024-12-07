using Microsoft.EntityFrameworkCore;
using WebAppKovaApi.Infrastructure;
using WebAppKovaApi.PackingListServises;
using WebAppKovaApi.PackingListServises.Contracts;
using WebAppKovaApi.PackingListServises.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<CustomExeptionFilter>();
});

builder.Services.AddControllers();
builder.Services.AddDbContext<WebAppKovaApi.Context.AppContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConStr")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApiProfile), typeof(SupplierSeviseProfile));
builder.Services.AddScoped<ISupplierServise, SupplerServise>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<AutorMidleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
