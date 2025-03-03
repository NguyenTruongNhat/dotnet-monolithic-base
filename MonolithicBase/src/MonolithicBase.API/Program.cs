using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using MonolithicBase.API.DependencyInjection.Extensions;
using MonolithicBase.API.Middleware;
using MonolithicBase.Application.DependencyInjection.Extensions;
using MonolithicBase.Infrastructure.Dapper.DependencyInjection.Extensions;
using MonolithicBase.Persistence.DependencyInjection.Extensions;
using MonolithicBase.Persistence.DependencyInjection.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging
    .ClearProviders()
    .AddSerilog();

builder.Host.UseSerilog();


builder.Services.AddConfigureMediatR();

builder
    .Services
    .AddControllers()
    .AddApplicationPart(MonolithicBase.Presentation.AssemblyReference.Assembly);

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Configure Options and SQL
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlConfiguration();
builder.Services.AddRepositoryBaseConfiguration();

builder.Services.AddConfigureAutoMapper();

// Configure Dapper
builder.Services.AddInfrastructureDapper();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services
        .AddSwaggerGenNewtonsoftSupport()
        .AddFluentValidationRulesToSwagger()
        .AddEndpointsApiExplorer()
        .AddSwagger();

builder.Services
    .AddApiVersioning(options => options.ReportApiVersions = true)
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();


// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
    app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
