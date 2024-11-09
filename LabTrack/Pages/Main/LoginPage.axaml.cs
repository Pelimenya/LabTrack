using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Microsoft.Extensions.DependencyInjection;

namespace LabTrack.Pages.Main;

public partial class LoginPage : UserControl
{


    public LoginPage()
    {
        InitializeComponent();
    }



    private void Check_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        TextBoxPassword.Text = PasswordBox.Text;
        PasswordBox.IsVisible = false;
        TextBoxPassword.IsVisible = true;
    }

    private void Check_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        PasswordBox.Text = TextBoxPassword.Text;
        TextBoxPassword.IsVisible = false;
        PasswordBox.IsVisible = true;
    }


    private void Button_Login(object? sender, RoutedEventArgs e)
    {
        IsEnabled = false;
        using (var scope = App.ServiceProvider.CreateScope())
        {
            // var _context = scope.ServiceProvider.GetRequiredService<AutoCenterDbContext>();
            // var person = await _context.Personals.FirstOrDefaultAsync(x => x.PersonalLogin == login.Text)!;
            // if (person != null && person.PersonalPassword == password.Text)
            // {
            //     var mainWindow = (MainWindow)this.VisualRoot;
            //     var mainPage = new MainPage();
            //     mainWindow.ContentArea.Content = mainPage;
            // }
            // else if (login.Text.IsNullOrEmpty() || password.Text.IsNullOrEmpty())
            // {
            //     AllertTb.Text = "Заполните все поля";
            //     IsEnabled = true;
            // }
            // else
            // {
            //     AllertTb.Text = "Неверный логин или пароль";
            //     IsEnabled = true;
            // }
        }
    }
}