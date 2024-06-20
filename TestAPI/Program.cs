using application.Handlers;
using Domain.Repositories;
using infrastructure.context;
using infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new AppDbContext(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserRepositories, userRepository>(provider =>
{
    var dbContext = provider.GetService<AppDbContext>();
    return new userRepository(dbContext.CreateConnection());
});//add scop to IuserRepository that giving to handlers from domain layer and give ConnectionString to them


builder.Services.AddMediatR(typeof(GetAllUSersHandler).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
