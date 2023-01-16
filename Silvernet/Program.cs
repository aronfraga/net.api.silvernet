using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Repository.IRepository;
using Silvernet.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("dbConnection");
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddDbContext<Context>(data => data.UseSqlServer(ConnectionString));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(data => {
	data.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	data.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(data => {
	data.RequireHttpsMetadata = false;
	data.SaveToken = true;
	data.TokenValidationParameters = new TokenValidationParameters {
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(data => {
	data.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
		Description = "Example: Bearer TOKEN_HERE",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Scheme = "Bearer"
	});
	data.AddSecurityRequirement(new OpenApiSecurityRequirement() {{
		new OpenApiSecurityScheme {
			Reference = new OpenApiReference {
				Type = ReferenceType.SecurityScheme,
				Id = "Bearer" 
			},
			Scheme = "oauth2",
			Name = "Bearer",
			In = ParameterLocation.Header 
		},
		new List<string>()
	}});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();