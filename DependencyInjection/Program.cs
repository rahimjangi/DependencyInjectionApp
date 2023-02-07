using Services;
using ServiceContracts;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    //containerBuilder.RegisterType<CitiesService>()
    //.As<ICitiesService>().InstancePerDependency();

    //containerBuilder.RegisterType<CitiesService>()
    //.As<ICitiesService>().SingleInstance();
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
