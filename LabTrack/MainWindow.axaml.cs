using Avalonia.Controls;
using LabTrack.Pages.Main;

namespace LabTrack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ContentArea.Content = new LoginPage();
    }
}