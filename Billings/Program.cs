using Billings.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .SetupServices();

builder.Logging.ClearProviders().AddConfiguration(builder.Configuration.GetSection("Logging")).AddConsole().AddDebug();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();