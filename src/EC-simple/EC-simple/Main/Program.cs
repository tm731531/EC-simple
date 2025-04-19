using System.Reflection;
using EC_simple.Main;
using EC_Simple_API.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<OrderJob>();
//builder.Services.AddHostedService<JobHostedService>();

// ���U�Ҧ� Job�]���Τ@�Ӥ@�� AddSingleton�^
builder.Services.RegisterAllJobWorkers(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<JobFactory>(); 
builder.Services.AddHostedService<DynamicJobHostedService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
