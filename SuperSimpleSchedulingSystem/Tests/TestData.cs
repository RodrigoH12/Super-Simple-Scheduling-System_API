using SuperSimpleSchedulingSystem.Data.Models;

namespace SuperSimpleSchedulingSystem.Tests
{
    public class TestData
    {
        public static User MockedUser => new()
        {
            Id = new("fa41365d-1456-4cd0-92d6-21dfaf38e404"),
            UserName = "ABC-12345",
            Password = "password",
        };
    }
}
