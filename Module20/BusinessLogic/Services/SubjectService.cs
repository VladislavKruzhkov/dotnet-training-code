using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _repo;

        private readonly IMapper _mapper;

        public SubjectService(IRepository<Subject> subjectRepo, IMapper mapper)
        {
            _repo = subjectRepo;
            _mapper = mapper;
        }

        public IEnumerable<SubjectDTO> GetAll()
        {
            var subjects = _repo.GetAll().Select(_mapper.Map<SubjectDTO>);
            return subjects;
        }

        public SubjectDTO GetById(int id) => _mapper.Map<SubjectDTO>(_repo.Get(id));

        public void Create(SubjectDTO item)
        {
            var subject = new Subject
            {
                SubjectId = item.SubjectId,
                Name = item.Name,
                ProfessorId = item.ProfessorId,
            };
            _repo.Create(subject);
        }

        public void Update(SubjectDTO subjectDto)
        {
            var subject = new Subject()
            {
                SubjectId = subjectDto.SubjectId,
                Name = subjectDto.Name,
                ProfessorId = subjectDto.ProfessorId,
            };
            _repo.Update(subject);
        }

        public void Delete(int id)
        {
            var subject = _repo.Get(id);
            if (subject != null) _repo.Delete(id);
        }
    }
}
