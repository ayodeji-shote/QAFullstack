using Microsoft.EntityFrameworkCore;
using QaFullStack.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EstateDBContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("EstateAgentAppCon2")));

// Cors allows client requests to be made from same (localhost) machine
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
		{   //policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
			policy.WithOrigins("http://localhost:3001").AllowAnyHeader().AllowAnyMethod();
		});
});

//create a static port for the API https://stackoverflow.com/questions/70332897/how-to-change-default-port-no-of-my-net-core-6-api
//builder.WebHost.UseUrls();

var app = builder.Build();

//the thing to add cors
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//app.UseSwagger();
	//app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
