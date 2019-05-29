using AulaLTP6.Infra.Configuration;
using Microsoft.Extensions.Configuration;

namespace AulaLTP6.API.Configuration
{
    public class ApiConfiguration : IDbConfiguration
    {
        private readonly IConfiguration _configuration;

        public ApiConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string stringConnection => _configuration.GetConnectionString("PROJLTP6");
    }
}
