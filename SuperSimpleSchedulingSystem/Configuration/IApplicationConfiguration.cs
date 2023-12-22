using SuperSimpleSchedulingSystem.Configuration.Models;

namespace SuperSimpleSchedulingSystem.Configuration
{
    public interface IApplicationConfiguration
    {
        DatabaseConnectionStrings GetDatabaseConnectionString();
    }
}
