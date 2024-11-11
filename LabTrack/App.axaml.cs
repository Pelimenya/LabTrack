using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LabTrack.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LabTrack;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public static IServiceProvider? ServiceProvider { get; set; }
    
    public override void OnFrameworkInitializationCompleted()
    {
        var serviseCollection = new ServiceCollection();
        ConfigureServices(serviseCollection);
        ServiceProvider  = serviseCollection.BuildServiceProvider();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private void ConfigureServices(IServiceCollection service)
    {
        service.AddDbContext<MedicalContext>(options => options.UseNpgsql("Host= localhost; port=5432; Database=MedicalLabDataBase; Username=Pelimenya; Password=root"));
        service.AddSingleton<MainWindow>();
    }
}