using Frontend.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ITestExecution, TestExecutionService>();
builder.Services.AddSingleton<Frontend.Server.Services.WebSocketProcessing>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseWebSockets();

app.Use(async (http, next) =>
{
    if (http.WebSockets.IsWebSocketRequest)
    {
        var socketProcessor = app.Services.GetRequiredService<Frontend.Server.Services.WebSocketProcessing>();
        await socketProcessor.Process(http);
    }
    else
    {
        await next();
    }
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
