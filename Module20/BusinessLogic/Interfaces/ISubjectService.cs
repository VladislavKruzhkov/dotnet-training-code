using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDTO> GetAll();
        SubjectDTO GetById(int id);
        void Create(SubjectDTO item);
        void Update(SubjectDTO item);
        void Delete(int id);
    }
}
