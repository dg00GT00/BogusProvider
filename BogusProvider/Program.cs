using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace BogusProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        var certificateConfig = context.Configuration.GetSection("Certificate");
                        var certFileName = certificateConfig["FileName"];
                        var certPassword = certificateConfig["Password"];
                        // Configure the Url and ports to bind to
                        // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
                        // overridden if you call UseIisIntegration() and host behind IIS/IIS Express
                        options.ListenLocalhost(5002, listenOptions =>
                        {
                            listenOptions.UseHttps(certFileName, certPassword);
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                    }).UseStartup<Startup>();
                });
    }
}