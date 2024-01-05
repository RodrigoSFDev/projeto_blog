using BlogApi;
using BlogApi.DataModel.Interfaces;
using BlogApi.Services;
using Microsoft.AspNetCore.Identity;
using BlogApi.DataModel;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJWTAuthenticationManager>(serviceProvider =>
{
    var userRepository = serviceProvider.GetRequiredService<IUserRepository>();
    return new JWTAuthenticationManager(userRepository, "string");
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Contexto>();
builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<Contexto>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins); //ADD Politica de segurança

app.MapControllers();

app.Run();
