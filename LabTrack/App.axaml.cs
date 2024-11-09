using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
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
        // service.AddDbContext<AutoCenterDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=AutoCenterDB;User Id=sa;Password=Root_2005;TrustServerCertificate=True"));
        // service.AddSingleton<MainWindow>();
    }
}