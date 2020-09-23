namespace FinantialCalculator.Api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseSentry("https://d65cdcbb0486404cbbaf1d3d421e344e@o439612.ingest.sentry.io/5436617")
                                     .UseStartup<Startup>();
                       });
        }
    }
}
