using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace EmployeeDirectoryServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((ctx,options) =>
                    {
                        if (ctx.HostingEnvironment.IsProduction())
                        {
                            options.Listen(IPAddress.Any, 5050, listenOptions =>
                            {
                                listenOptions.Protocols = HttpProtocols.Http2;
                            });
                        }
                        else
                        {
                            options.Listen(IPAddress.Any, 5050, listenOptions =>
                            {
                                listenOptions.Protocols = HttpProtocols.Http2;
                            });
                            options.Listen(IPAddress.Any, 5051, listenOptions =>
                            {
                                listenOptions.Protocols = HttpProtocols.Http1;
                            });
                        }
                       
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
