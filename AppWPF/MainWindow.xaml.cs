using System.Windows;

namespace AppWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly WebServer _server = new WebServer();

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
        Closed += (sender, e) => _server.Stop();
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("Iniciando servidor web...");
        var port = _server.Start();
        await webView.EnsureCoreWebView2Async();

#if DEBUG
        webView.CoreWebView2.Navigate("http://localhost:5173");
#else
        webView.CoreWebView2.Navigate($"http://localhost:{port}");
#endif
    }
}