using Income_Expense_Manager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IncomesDbContext>(config =>
                config.UseNpgsql(builder.Configuration.GetConnectionString("Default")));


// Add services to the container.
builder.Services.AddCors(config => config.AddPolicy("Default", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default"); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
