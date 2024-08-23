using SerializerSampleApi.Api;
using SerializerSampleApi.Api.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File($"bin/Logs/Log_{DateTime.Now:yyyyMMdd-HH-mm}.txt", encoding: System.Text.Encoding.UTF8)
    .CreateLogger();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
}).AddXmlSerializerFormatters();

builder.Services.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}else{
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();