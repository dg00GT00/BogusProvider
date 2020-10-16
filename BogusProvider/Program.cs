using System;
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
                        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER")))
                        {
                            // Insert a Docker entry on user-secrets when development in container
                            certFileName = certificateConfig["Docker"];
                        }

                        var certPassword = certificateConfig["Password"];
                        Console.WriteLine("CertificateName: {0}", certFileName);
                        Console.WriteLine("CertificatePassword: {0}", certPassword);
                        // Configure the Url and ports to bind to
                        // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
                        // overridden if you call UseIisIntegration() and host behind IIS/IIS Express
                        options.ListenAnyIP(5002, listenOptions =>
                        {
                            // When development in container, use ListenAnyIP method
                            listenOptions.UseHttps(certFileName, certPassword);
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                    }).UseStartup<Startup>();
                });
    }
}