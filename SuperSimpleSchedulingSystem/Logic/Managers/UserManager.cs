using AutoMapper;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;

namespace SuperSimpleSchedulingSystem.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> users = await _uow.UserRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            User user = await _uow.UserRepository.GetById(id)
                ?? throw new Exception($"User with Id {id} not found");

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new Exception("Fields should not be empty");
            }
            if (!userDto.IsValid())
            {
                throw new Exception("Invalid state");
            }
            if (await UserExists(userDto))
            {
                throw new Exception("The User already exists");
            }

            User newUser = _mapper.Map<User>(userDto);
            User createdUser = await _uow.UserRepository.Create(newUser);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> Update(Guid id, UserDto userDto)
        {
            if (userDto == null)
            {
                throw new Exception("Fields should not be empty");
            }
            if (!userDto.IsValid())
            {
                throw new Exception("Invalid state");
            }
            if (await UserExists(userDto))
            {
                throw new Exception("The User already exists");
            }

            User user = await _uow.UserRepository.GetById(id)
                ?? throw new Exception($"User with Id {id} not found");
            user.Password = userDto.Password;

            User updatedUser = await _uow.UserRepository.Update(user);
            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<bool> Delete(Guid id)
        {
            User user = await _uow.UserRepository.GetById(id)
                ?? throw new Exception($"User with Id {id} not found");

            await _uow.UserRepository.Delete(user);
            return await _uow.UserRepository.GetById(id) == null;
        }

        private async Task<bool> UserExists(UserDto userDto)
        {
            IEnumerable<User> users = await _uow.UserRepository.GetAll();
            return users.Any(c => c.UserName == userDto.UserName);
        }
    }
}
