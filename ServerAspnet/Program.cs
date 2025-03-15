using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Net;
using System.Net.NetworkInformation;

namespace ServerAspnet
{
    public class Program
    {
        public static int port = 0;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            });

            builder
                .Services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(typeof(Program).Assembly));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

#if !DEBUG
            // puerto dinámico (lo vemos en el siguiente punto)
            port = GetAvailablePort(5000);
            builder.WebHost.UseUrls($"http://localhost:{port}");
#endif

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.UseDefaultFiles(); // <-- Sirve index.html por defecto
            app.UseStaticFiles(); // <-- Sirve archivos de wwwroot

            app.MapGet("/api/demo", () => new { message = "¡Funciona! 🎉" });

            if (args.Any(x => x == "run_async"))
                app.RunAsync();
            else
                app.Run();
        }

        public static int GetAvailablePort(int startingPort)
        {
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            //getting active connections
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            portArray.AddRange(
                from n in connections
                where n.LocalEndPoint.Port >= startingPort
                select n.LocalEndPoint.Port
            );

            //getting active tcp listners - WCF service listening in tcp
            endPoints = properties.GetActiveTcpListeners();
            portArray.AddRange(from n in endPoints where n.Port >= startingPort select n.Port);

            //getting active udp listeners
            endPoints = properties.GetActiveUdpListeners();
            portArray.AddRange(from n in endPoints where n.Port >= startingPort select n.Port);

            portArray.Sort();

            for (int i = startingPort; i < UInt16.MaxValue; i++)
                if (!portArray.Contains(i))
                    return i;

            return 0;
        }
    }
}
