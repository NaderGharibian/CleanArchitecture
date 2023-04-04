using Autofac;
using Autofac.Extensions.DependencyInjection;
using Context;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new InfrastructureModule());
        containerBuilder.RegisterModule(new TestDBContextModule());
        containerBuilder.RegisterModule(new CoreModule());

    });
// Add services to the container.
builder.Services.AddDBContext()
                .AddVersioning().
                AddSwagger();


builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

var app = builder.Build();
IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "localhost")
{
    app.UseSwagger(options => { options.RouteTemplate = "api-docs/{documentName}/docs.json"; });
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "api-docs";
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/api-docs/{description.GroupName}/docs.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
