using Billings.Extensions;
using Billings.Infrastructure.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args)
    .SetupServices();

builder.Logging.ClearProviders().AddConfiguration(builder.Configuration.GetSection("Logging")).AddConsole().AddDebug();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<BillingDbContext>();
    db.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();