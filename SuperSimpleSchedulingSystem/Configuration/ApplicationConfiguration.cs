using SuperSimpleSchedulingSystem.Configuration.Models;
using Microsoft.Extensions.Configuration;

namespace SuperSimpleSchedulingSystem.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IConfiguration _configuration;

        public ApplicationConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DatabaseConnectionStrings GetDatabaseConnectionString()
        {
            return new DatabaseConnectionStrings()
            {
                DATABASE = _configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value
            };
        }
    }
}
