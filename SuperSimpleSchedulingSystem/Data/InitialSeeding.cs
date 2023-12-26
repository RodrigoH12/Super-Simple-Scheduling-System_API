using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Models.Enums;

namespace SuperSimpleSchedulingSystem.Data
{
    public class InitialSeeding
    {
        public static IEnumerable<User> SeedUsers => new List<User>
        {
            new() {
                Id = new Guid("3B9EF2B3-44F4-4B0A-8C4A-08DB4D6C094C"),
                UserName = "rodrigo.heredia",
                Password = "Pass123"
            },
            new() {
                Id = new Guid("4890F590-F25E-45D8-9E78-08DB4D6C094C"),
                UserName = "john.peterson",
                Password = "12345.J"
            },
            new() {
                Id = new Guid("B821E05D-873A-481E-8C4B-08DB4D6C094C"),
                UserName = "camila.peredo",
                Password = "CaMi!23"
            },
            new() {
                Id = new Guid("AA4FBDBA-35F7-45B5-9E88-08DB4D6C094C"),
                UserName = "christopher.davies",
                Password = "Password321"
            },
            new() {
                Id = new Guid("61BC6E41-7D14-4CF2-9E87-08DB4D6C094C"),
                UserName = "jessica.brown",
                Password = "TestingTesting@"
            },
            new() {
                Id = new Guid("3C66C9FA-8759-45D7-9E8A-08DB4D6C094C"),
                UserName = "brian.anderson",
                Password = "He1loWorlD"
            }
        };

        public static IEnumerable<Student> SeedStudents => new List<Student>
        {
            new() {
                Id = new Guid("F5D72E55-A870-4F1A-9E80-08DB4D6C094C"),
                FirstName = "Rodrigo",
                LastName = "Heredia",
                UserId = new Guid("3B9EF2B3-44F4-4B0A-8C4A-08DB4D6C094C")
            },
            new() {
                Id = new Guid("9BC9A0EC-F5E1-42B5-9E82-08DB4D6C094C"),
                FirstName = "John",
                LastName = "Peterson",
                UserId = new Guid("4890F590-F25E-45D8-9E78-08DB4D6C094C")
            },
            new() {
                Id = new Guid("7FAE9A91-4C35-4E57-9E83-08DB4D6C094C"),
                FirstName = "Camila",
                LastName = "Peredo",
                UserId = new Guid("B821E05D-873A-481E-8C4B-08DB4D6C094C")
            },
            new() {
                Id = new Guid("F98231C8-9D22-4C69-9E84-08DB4D6C094C"),
                FirstName = "Christopher",
                LastName = "Davis",
                UserId = new Guid("AA4FBDBA-35F7-45B5-9E88-08DB4D6C094C")
            },
            new() {
                Id = new Guid("A7F570F2-0B1B-4779-9E85-08DB4D6C094C"),
                FirstName = "Jessica",
                LastName = "Brown",
                UserId = new Guid("61BC6E41-7D14-4CF2-9E87-08DB4D6C094C")
            },
            new() {
                Id = new Guid("E2D8CC80-29CA-45B1-9E89-08DB4D6C094C"),
                FirstName = "Brian",
                LastName = "Anderson",
                UserId = new Guid("3C66C9FA-8759-45D7-9E8A-08DB4D6C094C")
            }
        };

        public static IEnumerable<Class> SeedClasses => new List<Class>
        {
            new() {
                Id = new Guid("2F29C595-2E96-40D5-9E86-08DB4D6C094C"),
                Title = "Introduction to Programming with Javascript",
                Description = "In this class you will learn the fundamentals of Javascript thanks to the realization of multiple projects",
                Teacher = "Jhon Petersonn",
                Schedule = ScheduleEnum.A
            },
            new() {
                Id = new Guid("A0D208E3-2B70-4C31-9E8B-08DB4D6C094C"),
                Title = "Data Structures and Algorithms",
                Description = "Explore the fundamental concepts of data structures and algorithms, with hands-on coding exercises.",
                Teacher = "Alice Johnson",
                Schedule = ScheduleEnum.B
            },
            new() {
                Id = new Guid("4C84C62B-B98F-4670-9E88-08DB4D6C094C"),
                Title = "Web Development Basics",
                Description = "Learn the basics of web development, including HTML, CSS, and JavaScript.",
                Teacher = "Bob Smith",
                Schedule = ScheduleEnum.C
            },
            new() {
                Id = new Guid("646A14A8-9A45-4C79-9E87-08DB4D6C094C"),
                Title = "Database Design and SQL",
                Description = "Understand the principles of database design and master SQL for effective data management.",
                Teacher = "Charlie Brown",
                Schedule = ScheduleEnum.A
            },new() {
                Id = new Guid("D8276C8F-84E5-41FA-9E8C-08DB4D6C094C"),
                Title = "Mobile App Development with React Native",
                Description = "Build cross-platform mobile applications using React Native and modern JavaScript frameworks.",
                Teacher = "Diana Miller",
                Schedule = ScheduleEnum.D
            },
            new() {
                Id = new Guid("C791A7A4-625E-4A46-9E90-08DB4D6C094C"),
                Title = "Cybersecurity Fundamentals",
                Description = "Explore the basics of cybersecurity and learn essential techniques to secure computer systems.",
                Teacher = "Edward Turner",
                Schedule = ScheduleEnum.B
            },
            new() {
                Id = new Guid("A9BB7A24-F2BB-4FAF-9E91-08DB4D6C094C"),
                Title = "Cloud Computing Intermediate",
                Description = "Get an introduction to cloud computing and popular cloud platforms like AWS and Azure.",
                Teacher = "Jack Miller",
                Schedule = ScheduleEnum.B
            },
            new() {
                Id = new Guid("B0A1221C-414F-45D6-9E92-08DB4D6C094C"),
                Title = "Artificial Intelligence Fundamentals",
                Description = "Dive into the basics of artificial intelligence and machine learning algorithms.",
                Teacher = "Grace Watson",
                Schedule = ScheduleEnum.C
            },
            new() {
                Id = new Guid("08CB5F72-944F-4E9C-9E94-08DB4D6C094C"),
                Title = "Software Engineering Best Practices",
                Description = "Explore the best practices in software engineering for creating maintainable and scalable applications.",
                Teacher = "Henry White",
                Schedule = ScheduleEnum.D
            },
            new() {
                Id = new Guid("6EEAB56D-9357-43A5-9E96-08DB4D6C094C"),
                Title = "Network Security",
                Description = "Learn the essentials of network security, including encryption, firewalls, and intrusion detection.",
                Teacher = "Ivy Robinson",
                Schedule = ScheduleEnum.A,
            }
        };
    }
}
