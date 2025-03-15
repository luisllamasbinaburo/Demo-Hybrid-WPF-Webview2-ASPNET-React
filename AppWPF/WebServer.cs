using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AppWPF
{
    public class WebServer
    {
        private WebApplication? _app;

        public int Start()
        {
            try
            {
                Console.WriteLine("Iniciando servidor web...");
                ServerAspnet.Program.Main(new string[] { "run_async" });

                var port = ServerAspnet.Program.port;
                Console.WriteLine($"Iniciado en {port}");
                return port;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el servidor: {ex.Message}");
                return 0;
            }
        }

        public void Stop() => _app?.StopAsync();
    }
}
