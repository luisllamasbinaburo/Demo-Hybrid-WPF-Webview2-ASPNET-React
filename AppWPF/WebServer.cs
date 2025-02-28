using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AppWPF
{
    public class WebServer
    {
        private WebApplication? _app;

        public void Start()
        {
            try
            {
                ServerAspnet.Program.Main(new string[] { "run_async" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el servidor: {ex.Message}");
            }
        }
        
        public void Stop() => _app?.StopAsync();
    }
}
