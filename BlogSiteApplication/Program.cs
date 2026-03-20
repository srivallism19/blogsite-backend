using UserBlogSite.DapperHelper;
using UserBlogSite.Interfaces.Repositories;
using UserBlogSite.Interfaces.Services;
using UserBlogSite.Repositories;
using UserBlogSite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDapperHelper, DapperHelper>();
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnguarApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnguarApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
