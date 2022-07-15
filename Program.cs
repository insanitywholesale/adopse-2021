using adopse_2021.Models;

using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_MyAllowAllPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
	options.AddPolicy(name: MyAllowSpecificOrigins,
		builder => {
			builder.WithOrigins("*")
				.SetIsOriginAllowedToAllowWildcardSubdomains()
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});

// Add services to the container
builder.Services.AddControllers();

// Choose between PostgreSQL and In-Memory
if (builder.Environment.IsDevelopment()) {
	builder.Services.AddDbContext<EvaluationContext>(options => {
		options.UseInMemoryDatabase("EvaluationRepo");
	});
} else {
	builder.Services.AddDbContext<EvaluationContext>(options => {
		options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
	});
}

// Make route urls and query strings lowercase
builder.Services.AddRouting(options => {
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
// Set up swagger docs
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
