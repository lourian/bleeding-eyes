using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Cinema.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Cinema.Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
