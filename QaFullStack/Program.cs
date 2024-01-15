using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QaFullStack.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD

builder.Services.AddDbContext<EstateDBContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("EstateAgentAppCon")));

//json selializer
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

// Add services to the container.
var app = builder.Build();


app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
=======
builder.Services.AddDbContext<EstateDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EstateAgentAppCon")));

// json serializer
builder.Services.AddControllers().AddNewtonsoftJson(options=>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options=>options.SerializerSettings.ContractResolver=new Newtonsoft.Json.Serialization.DefaultContractResolver());

var app = builder.Build();

app.UseCors(c=>c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
>>>>>>> ec121d4b8fc53ec4e857893a56b7919d17583d9f
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
