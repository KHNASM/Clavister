using System.IO.IsolatedStorage;
using System.Windows;
using Clavister.ToDo.DataWriter;
using Clavister.ToDo.Storage.Abstraction;
using Clavister.ToDo.Storage.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clavister.ToDo.Ui;

public partial class App : Application
{
    public static IHost AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            services.AddSingleton<MainWindow>();
            services.AddScoped<IStorage, LocalStore>();
            services.AddScoped<IDataSerializer, DataSerializer>();
        }).Build();
    }

    
    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost.StartAsync();
        var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
        startUpForm.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost.StopAsync();

        base.OnExit(e);
    }
}