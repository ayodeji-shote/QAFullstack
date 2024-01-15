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

builder.Services.AddControllers();

=======
builder.Services.AddDbContext<EstateDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EstateAgentAppCon")));
>>>>>>> 828845f87a793e21ec23fd987b215355c3077c54
// json serializer
builder.Services.AddControllers().AddNewtonsoftJson(options=>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options=>options.SerializerSettings.ContractResolver=new Newtonsoft.Json.Serialization.DefaultContractResolver());

<<<<<<< HEAD
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

=======
>>>>>>> 828845f87a793e21ec23fd987b215355c3077c54
var app = builder.Build();


app.UseCors(c=>c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
