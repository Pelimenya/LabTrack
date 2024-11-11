using System;
using System.Security.Cryptography;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LabTrack.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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


    private async void Button_Login(object? sender, RoutedEventArgs e)
    {
        string enteredLogin = LoginBox.Text;
        string enteredPassword = PasswordBox.Text;
        IsEnabled = false;
        using SHA256 sha256 = SHA256.Create();
        byte[] hashedPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
        string hashedPassword = BitConverter.ToString(hashedPasswordBytes).Replace("-", "").ToLower();
        using (var scope = App.ServiceProvider.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<MedicalContext>();
            var person = await _context.Doctors.Include(x => x.IdSpecializationNavigation).FirstOrDefaultAsync(x => x.Login == enteredLogin)!;
            if (person != null && person.Password == hashedPassword)
            {
                if (person.IdSpecializationNavigation.SpecializationName == "admin")
                {
                    var mainWindow = (MainWindow)this.VisualRoot;
                    var adminMenuPage= new AdminMenuPage();
                    mainWindow.ContentArea.Content = adminMenuPage;    
                }
                else
                {
                var mainWindow = (MainWindow)this.VisualRoot;
                var menuPage= new MenuPage();
                mainWindow.ContentArea.Content = menuPage;
                }
            }
            else if (enteredLogin.IsNullOrEmpty() || enteredPassword.IsNullOrEmpty())
            {
                AllertTb.Text = "Заполните все поля";
                IsEnabled = true;
            }    
            else
            {
                AllertTb.Text = "Неверный логин или пароль";
                IsEnabled = true;
            }
        }
    }
}