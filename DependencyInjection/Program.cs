using Services;
using ServiceContracts;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using DependencyInjection.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

builder.Services.Configure<MyApiOptions>(builder.Configuration.GetSection("MyApi"));

//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
//{
//    //containerBuilder.RegisterType<CitiesService>()
//    //.As<ICitiesService>().InstancePerDependency();

//    //containerBuilder.RegisterType<CitiesService>()
//    //.As<ICitiesService>().SingleInstance();
//});
builder.Services.AddScoped<ICitiesService, CitiesService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
}



app.UseStaticFiles();
app.UseRouting();

//app.UseEndpoints(endpoints => {
//    endpoints.Map("/mykeies", async (context) =>
//    {
//        app.Configuration
//    });


//});

app.MapControllers();
app.Run();
