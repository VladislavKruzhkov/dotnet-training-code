using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repo;

        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> studentRepo, IMapper mapper)
        {
             _repo = studentRepo;
             _mapper = mapper;
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var students = _repo.GetAll().Select(_mapper.Map<StudentDTO>);
            return students;
        }

        public StudentDTO GetById(int id) => _mapper.Map<StudentDTO>(_repo.Get(id));

        public void Create(StudentDTO item)
        {
            var student = new Student
            {
                StudentId = item.StudentId,
                Name = item.Name,
                Surname = item.Surname,
            };
            _repo.Create(student);
        }

        public void Update(StudentDTO studentDto)
        {
            var student = new Student
            {
                StudentId = studentDto.StudentId,
                Name = studentDto.Name,
                Surname = studentDto.Surname,
            };
            _repo.Update(student);
        }

        public void Delete(int id)
        {
            var student = _repo.Get(id);
            if (student != null) _repo.Delete(id);
        }
    }
}
