using AutoMapper;
using Moq;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Logic.Managers;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Logic.Models.Mapper;

namespace SuperSimpleSchedulingSystem.Tests.Logic
{
    [TestFixture]
    public class UserManagerTests
    {
        private UserManager _userManager;
        private Mock<IUnitOfWork> _uowMock;

        [SetUp]
        public void Setup()
        {
            _uowMock = new Mock<IUnitOfWork>();
            IMapper mapper = GetMapper();

            _userManager = new UserManager(_uowMock.Object, mapper);
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
        public async Task GetById_UserId_ReturnsExpectedUser()
        {
            // Arrange
            Guid userId = new("fa41365d-1456-4cd0-92d6-21dfaf38e404");

            _uowMock.Setup(u => u.UserRepository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(TestData.MockedUser);

            // Act
            var result = await _userManager.GetById(userId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.UserName, Is.EqualTo(TestData.MockedUser.UserName));
                Assert.That(result.Password, Is.EqualTo(TestData.MockedUser.Password));
            });
        }

        [Test]
        public async Task Create_User_ReturnsCreatedUser()
        {
            // Arrange
            UserDto newUser = new()
            {
                Id = new("c8b6bc1a-dec2-45e3-a70c-0d05f4825f91"),
                UserName = "NewUser",
                Password = "NewPassword",
            };

            _uowMock.Setup(u => u.UserRepository.GetAll())
                .ReturnsAsync(new List<User> { });

            _uowMock.Setup(u => u.UserRepository.Create(It.IsAny<User>()))
                .ReturnsAsync(GetMapper().Map<User>(newUser));

            // Act
            var result = await _userManager.Create(newUser);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.UserName, Is.EqualTo(newUser.UserName));
                Assert.That(result.Password, Is.EqualTo(newUser.Password));
            });
        }
    }
}
