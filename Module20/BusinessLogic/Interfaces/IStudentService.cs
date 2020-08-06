using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();
        StudentDTO GetById(int id);
        void Create(StudentDTO item);
        void Update(StudentDTO item);
        void Delete(int id);
    }
}
