
namespace ServerAspnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

        
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.UseDefaultFiles(); // <-- Sirve index.html por defecto
            app.UseStaticFiles();  // <-- Sirve archivos de wwwroot
            app.MapFallbackToFile("index.html"); // <-- Para rutas de React

            app.MapGet("/api/demo", () => new { message = "¡Funciona! 🎉" });

            if(args.Any(x=> x=="run_async")) app.RunAsync();
            else app.Run();

        }
    }
}
