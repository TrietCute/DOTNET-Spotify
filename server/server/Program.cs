using GameStore.Data;
using server.Data;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connString = builder.Configuration.GetConnectionString("MusicApp");
            builder.Services.AddSqlite<MusicAppContext>(connString);

            var app = builder.Build();
            app.MigrateDb();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
