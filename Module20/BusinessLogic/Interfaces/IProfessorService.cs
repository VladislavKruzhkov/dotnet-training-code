using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IProfessorService
    {
        IEnumerable<ProfessorDTO> GetAll();
        ProfessorDTO GetById(int id);
        void Create(ProfessorDTO item);
        void Update(ProfessorDTO item);
        void Delete(int id);
    }
}