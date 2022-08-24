using Microsoft.Extensions.Configuration;

namespace Domain.core.Token
{
    public static class Configuration
    {
        public static string Secret()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            return config.GetValue<string>("Secret");
        }
    }
}