using adopse_2021.Models;

using Microsoft.EntityFrameworkCore;

using static System.Environment;

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

// Add services to the container.

builder.Services.AddControllers();

// Choose between PostgreSQL and In-Memory
var usePostgres = System.Environment.GetEnvironmentVariable("USE_POSTGRES");

if (usePostgres == "true") {
	builder.Services.AddDbContext<EvaluationContext>(options => {
		options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
	});
} else {
	builder.Services.AddDbContext<EvaluationContext>(options => {
		options.UseInMemoryDatabase("EvaluationRepo");
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
} else {
	// Moved here because we don't need HTTPS in development
	app.UseHttpsRedirection();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

