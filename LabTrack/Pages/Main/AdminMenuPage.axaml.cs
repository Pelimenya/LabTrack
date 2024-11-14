using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LabTrack.Pages.AdminPages;

namespace LabTrack.Pages.Main;

public partial class AdminMenuPage : UserControl
{
    public AdminMenuPage()
    {
        InitializeComponent();
        ContentFrame.Content = new MainFormPage();
    }

    private void NavigateToMainForm(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new MainFormPage();
    }

    private void NavigateToPatientManagement(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new PatientManagement();
    }

    private void NavigateToDoctorManagement(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new DoctorManagementPage();
    }

    private void NavigateToScheduleManagement(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new ScheduleManagement();
    }

    private void NavigateToScheduleExceptions(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new ScheduleExceptions();
    }

    private void NavigateToStatistics(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new Statistics();
    }

    private void NavigateToSearch(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new SearchPage();
    }

    private void NavigateToAbout(object? sender, RoutedEventArgs e)
    {
        ContentFrame.Content = new AboutPage();
    }

    private void PaneOpen(object? sender, RoutedEventArgs e)
    {
        SV.IsPaneOpen = !SV.IsPaneOpen;
    }

    private void NavigateToLogin(object? sender, RoutedEventArgs e)
    {
        App.IdDoctor = null;
        MainWindow mainWindow = (MainWindow)this.VisualRoot;
        LoginPage loginPage = new LoginPage();
        mainWindow.ContentArea.Content = loginPage;
    }
}