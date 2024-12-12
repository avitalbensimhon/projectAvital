using Project.core.Reposetory;
using Project.core.Servies;
using Project.Data;
using Project.Data.Reposetory;
using Project.Servies;
using projectAvital;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGuideServies, GuideServies>();
builder.Services.AddScoped<IGuideReposetory, GuideReposetory>();
builder.Services.AddScoped<IRegisteresServies, RegisteresServies>();
builder.Services.AddScoped<IRegisteresReposetory, RegisteresReposetory>();
builder.Services.AddScoped<ITripServies, TripServies>();
builder.Services.AddScoped<ITripReposetory, TripReposetory>();

builder.Services.AddDbContext<Datacontext>();
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
