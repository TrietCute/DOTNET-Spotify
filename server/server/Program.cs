using GameStore.Data;
using server.Data;
using server.Endpoints;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
                // Other logging providers
            });
            var connString = builder.Configuration.GetConnectionString("MusicApp");
            builder.Services.AddSqlite<MusicAppContext>(connString);

            var app = builder.Build();
            app.MapGet("/", () => "Hello World!");
            app.MapAuthEndpoints();
            app.MigrateDb();

           

            app.Run();
        }
    }
}
