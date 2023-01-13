using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Repository.IRepository;
using Silvernet.Repository;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("dbConnection");
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddDbContext<Context>(data => data.UseSqlServer(ConnectionString));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();