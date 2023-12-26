using AutoMapper;
using SuperSimpleSchedulingSystem.Data;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Logic.Exceptions;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;

namespace SuperSimpleSchedulingSystem.Logic.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StudentManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            IEnumerable<Student> students = await _uow.StudentRepository.GetAll();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetById(Guid id)
        {
            Student student = await _uow.StudentRepository.GetById(id)
                ?? throw new NotFoundException($"Student with Id {id} not found");

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> Create(StudentDto studentDto)
        {
            if (studentDto == null)
            {
                throw new BadRequestException("Fields should not be empty");
            }
            if (!studentDto.IsValid())
            {
                throw new BadRequestException("Invalid state");
            }
            if (await StudentExists(studentDto))
            {
                throw new AlreadyExistException("The exact same Student already exists");
            }

            Student newStudent = _mapper.Map<Student>(studentDto);
            Student createdStudent = await _uow.StudentRepository.Create(newStudent);
            return _mapper.Map<StudentDto>(createdStudent);
        }

        public async Task<StudentDto> Update(Guid id, StudentDto studentDto)
        {
            if (studentDto == null)
            {
                throw new BadRequestException("Fields should not be empty");
            }
            if (!studentDto.IsValid())
            {
                throw new BadRequestException("Invalid state");
            }
            if (await StudentExists(studentDto))
            {
                throw new AlreadyExistException("The exact same Student already exists");
            }

            Student student = await _uow.StudentRepository.GetById(id)
                ?? throw new NotFoundException($"Student with Id {id} not found");
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;

            Student updatedStudent = await _uow.StudentRepository.Update(student);
            return _mapper.Map<StudentDto>(updatedStudent);
        }

        public async Task<bool> Delete(Guid id)
        {
            Student student = await _uow.StudentRepository.GetById(id)
                ?? throw new NotFoundException($"Student with Id {id} not found");

            await _uow.StudentRepository.Delete(student);
            return await _uow.StudentRepository.GetById(id) == null;
        }

        private async Task<bool> StudentExists(StudentDto studentDto)
        {
            IEnumerable<Student> students = await _uow.StudentRepository.GetAll();
            return students.Any(c => c.FirstName == studentDto.FirstName && c.LastName == studentDto.LastName
                && c.UserId == studentDto.UserId);
        }
    }
}
