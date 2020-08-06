using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BusinessLogic.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IRepository<Professor> _repo;

        private readonly IMapper _mapper;

        public ProfessorService(IRepository<Professor> professorRepo, IMapper mapper)
        {
            _repo = professorRepo;
            _mapper = mapper;
        }

        public IEnumerable<ProfessorDTO> GetAll()
        {
            var professors = _repo.GetAll().Select(_mapper.Map<ProfessorDTO>);
            return professors;
        }

        public ProfessorDTO GetById(int id) => _mapper.Map<ProfessorDTO>(_repo.Get(id));

        public void Create(ProfessorDTO item)
        {
            var professor = new Professor
            {
                ProfessorId = item.ProfessorId,
                Name = item.Name,
                Surname = item.Surname,
                Subjects = _mapper.Map<List<SubjectDTO>, List<Subject>>(item.Subjects)
            };
            _repo.Create(professor);
        }

        public void Update(ProfessorDTO professorDto)
        {
            var professorToUpdate = new Professor()
            {
                ProfessorId = professorDto.ProfessorId,
                Name = professorDto.Name,
                Surname = professorDto.Surname,
                Subjects = _mapper.Map<List<SubjectDTO>, List<Subject>>(professorDto.Subjects)
            };
            _repo.Update(professorToUpdate);
        }

        public void Delete(int id)
        {
            var professor = _repo.Get(id);
            if (professor != null) _repo.Delete(id);
        }
    }
}
