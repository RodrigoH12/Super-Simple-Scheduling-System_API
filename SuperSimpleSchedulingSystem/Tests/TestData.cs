using SuperSimpleSchedulingSystem.Data.Models;

namespace SuperSimpleSchedulingSystem.Tests
{
    public class TestData
    {
        public static User MockedUser => new()
        {
            Id = new("fa41365d-1456-4cd0-92d6-21dfaf38e404"),
            UserName = "ABC-12345",
            Password = "password"
        };

        public static Student MockedStudent => new()
        {
            Id = new("c8b6bc1a-dec2-45e3-a70c-0d05f4825f91"),
            FirstName = "User",
            LastName = "Testing",
            UserId = new("fa41365d-1456-4cd0-92d6-21dfaf38e404"),
            Classes = new List<Class>()
        };

        public static Class MockedClass => new()
        {
            Id = new("3387172f-8e63-4677-9823-b35b2a31c58d"),
            Title = "Testing Class",
            Description = "This is a description for testing class",
            Teacher = "Testing teacher",
            Schedule = Data.Models.Enums.ScheduleEnum.C,
            Students = new List<Student>()
        };
    }
}
