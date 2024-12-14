using Microsoft.EntityFrameworkCore;
using WebApiKovaApi.Common;
using WebApiKovaApi.Common.Abstractions;
using WebApiKovaApi.Repositories;
using WebApiKovaApi.Repositories.Contracts;
using WebAppKovaApi.Context.Contracts;
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

builder.Services.AddScoped<IReader>(c => c.GetRequiredService<WebAppKovaApi.Context.AppContext>());
builder.Services.AddScoped<IWriter>(c => c.GetRequiredService<WebAppKovaApi.Context.AppContext>());
builder.Services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<WebAppKovaApi.Context.AppContext>());

builder.Services.AddScoped<ISupplierWriteRepository, SupplierWriteRepository>();
builder.Services.AddScoped<ISupplierReadRepository, SupplierReadRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApiProfile), typeof(SupplierSeviseProfile));

builder.Services.AddScoped<ISupplierServise, SupplerServise>();
builder.Services.AddSingleton<ISupplierValidationServise, SupplierValidationServise>();
builder.Services.AddSingleton<IDataTimeProvider, DataTimeProvider>();

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
