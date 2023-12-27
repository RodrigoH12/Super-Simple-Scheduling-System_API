using AutoMapper;
using FluentAssertions;
using Moq;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Logic.Exceptions;
using SuperSimpleSchedulingSystem.Logic.Managers;
using SuperSimpleSchedulingSystem.Logic.Models.Mapper;

namespace SuperSimpleSchedulingSystem.Tests.Logic
{
    public class ClassManagerTests
    {
        private ClassManager _classManager;
        private Mock<IUnitOfWork> _uowMock;

        [SetUp]
        public void Setup()
        {
            _uowMock = new Mock<IUnitOfWork>();
            IMapper mapper = GetMapper();

            _classManager = new ClassManager(_uowMock.Object, mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        [Test]
        public async Task AssignStudentToClass_ClassId_StudentId_ThrowsNotfoundException()
        {
            // Arrange
            Guid studentId = new("c8b6bc1a-dec2-45e3-a70c-0d05f4825f91");
            Guid classId = new("3387172f-8e63-4677-9823-b35b2a31c58d");

            Class expectedClass = TestData.MockedClass;
            expectedClass.Students.Add(TestData.MockedStudent);

            _uowMock.Setup(u => u.ClassRepository.GetClassByIdIncludingStudents(It.IsAny<Guid>()))
                .ReturnsAsync(expectedClass);

            _uowMock.Setup(u => u.StudentRepository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((Student)null);

            // Act
            Func<Task> result = async () => await _classManager.AssignStudentToClass(classId, studentId);

            // Assert
            await result.Should().ThrowAsync<NotFoundException>()
                .WithMessage($"Student with Id {studentId} not found");
        }
    }
}
