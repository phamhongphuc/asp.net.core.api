using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace blog.server
{
    /// <summary>
    /// The Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method - the Start Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create Web Host Builder
        /// </summary>
        /// <param name="args"></param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
