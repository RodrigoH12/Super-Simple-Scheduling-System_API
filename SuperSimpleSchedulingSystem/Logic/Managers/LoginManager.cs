using AutoMapper;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Logic.Exceptions;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleSchedulingSystem.Logic.Managers
{
    public class LoginManager : ILoginManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LoginManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDto> Login(string username, string password)
        {
            User user = await _uow.UserRepository.Login(username, password)
                ?? throw new NotFoundException($"The username or password is incorrect");

            return _mapper.Map<UserDto>(user);
        }
    }
}
