using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using LabTrack.Pages.Main;

namespace LabTrack;

public partial class MainWindow : Window
{
    private bool _isDragging;
    private Point _startPoint;
    public MainWindow()
    {
        InitializeComponent();
        ContentArea.Content = new LoginPage();
    }
    
    private void OnTitleBarPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            _isDragging = true;
            _startPoint = e.GetPosition(this);
            BeginMoveDrag(e); 
        }
    }

    private void OnTitleBarPointerMoved(object? sender, PointerEventArgs e)
    {
       
        if (_isDragging)
        {
            var currentPosition = e.GetPosition(this);
            this.Position = new PixelPoint(
                (int)(Position.X + (currentPosition.X - _startPoint.X)),
                (int)(Position.Y + (currentPosition.Y - _startPoint.Y)));
        }
    }

    private void OnTitleBarPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
      
        _isDragging = false;
    }
}