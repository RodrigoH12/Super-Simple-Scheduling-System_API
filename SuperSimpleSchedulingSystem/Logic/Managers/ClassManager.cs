using AutoMapper;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;

namespace SuperSimpleSchedulingSystem.Logic.Managers
{
    public class ClassManager : IClassManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ClassManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassDto>> GetAll()
        {
            IEnumerable<Class> classes = await _uow.ClassRepository.GetAll();
            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<ClassDto> GetById(Guid id)
        {
            Class specificClass = await _uow.ClassRepository.GetById(id)
                ?? throw new Exception($"Class with Id {id} not found");

            return _mapper.Map<ClassDto>(specificClass);
        }

        public async Task<ClassDto> Create(ClassDto classDto)
        {
            if (classDto == null)
            {
                throw new Exception("Fields should not be empty");
            }
            if (!classDto.IsValid())
            {
                throw new Exception("Invalid state");
            }
            if (await ClassExists(classDto))
            {
                throw new Exception("The exact same Class already exists");
            }

            Class newClass = _mapper.Map<Class>(classDto);
            Class createdClass = await _uow.ClassRepository.Create(newClass);
            return _mapper.Map<ClassDto>(createdClass);
        }

        public async Task<ClassDto> Update(Guid id, ClassDto classDto)
        {
            if (classDto == null)
            {
                throw new Exception("Fields should not be empty");
            }
            if (!classDto.IsValid())
            {
                throw new Exception("Invalid state");
            }
            if (await ClassExists(classDto))
            {
                throw new Exception("The exact same Class already exists");
            }

            Class specificClass = await _uow.ClassRepository.GetById(id)
                ?? throw new Exception($"Class with Id {id} not found");
            specificClass.Description = classDto.Description;
            specificClass.Teacher = classDto.Teacher;
            specificClass.Schedule = classDto.Schedule;

            Class updatedClass = await _uow.ClassRepository.Update(specificClass);
            return _mapper.Map<ClassDto>(updatedClass);
        }

        public async Task<bool> Delete(Guid id)
        {
            Class specificClass = await _uow.ClassRepository.GetById(id)
                ?? throw new Exception($"Class with Id {id} not found");

            await _uow.ClassRepository.Delete(specificClass);
            return await _uow.ClassRepository.GetById(id) == null;
        }

        private async Task<bool> ClassExists(ClassDto classDto)
        {
            IEnumerable<Class> classes = await _uow.ClassRepository.GetAll();
            return classes.Any(c=> c.Title == classDto.Title && c.Teacher == classDto.Teacher
                && c.Schedule == classDto.Schedule);
        }
    }
}
