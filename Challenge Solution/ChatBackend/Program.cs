using ChatBackend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000"); // React dev server
    });
});


var app = builder.Build();
app.UseCors();

app.MapGet("/", () => "Hello World!");

app.MapHub<ChatHub>("/chatHub");

app.Run();
