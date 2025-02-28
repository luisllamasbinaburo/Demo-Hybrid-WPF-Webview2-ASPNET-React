using System.Windows;

namespace HybridAppWPF;

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
        _server.Start();
        await webView.EnsureCoreWebView2Async();

#if DEBUG
        webView.CoreWebView2.Navigate("http://localhost:5173"); // React dev server
#else
        webView.CoreWebView2.Navigate("http://localhost:5000");
#endif
    }
}