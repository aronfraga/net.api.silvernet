using Microsoft.EntityFrameworkCore;
using Silvernet.Data;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("dbConnection");
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddDbContext<Context>(data => data.UseSqlServer(ConnectionString));

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