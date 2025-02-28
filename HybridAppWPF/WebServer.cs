using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HybridAppWPF
{
    public class WebServer
    {
        private WebApplication? _app;

        public void Start()
        {
            try
            {
                var builder = WebApplication.CreateBuilder();

                builder.Services.AddControllers();
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy(
                        "AllowAll",
                        policy =>
                        {
                            policy
#if DEBUG
                            .WithOrigins("http://localhost:5173")
#endif
                            .AllowAnyMethod().AllowAnyHeader();
                        }
                    );
                });

                _app = builder.Build();

                _app.UseCors("AllowAll");

                _app.MapControllers();

                _app.UseDefaultFiles(); // <-- Sirve index.html por defecto
                _app.UseStaticFiles();  // <-- Sirve archivos de wwwroot
                _app.MapFallbackToFile("index.html"); // <-- Para rutas de React

                _app.MapGet("/api/demo", () => new { message = "¡Funciona! 🎉" });

                _app.RunAsync(); // Iniciar en segundo plano
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el servidor: {ex.Message}");
            }
        }
        
        public void Stop() => _app?.StopAsync();
    }
}
