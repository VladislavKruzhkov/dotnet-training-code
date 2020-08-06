using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IAttendanceService
    {
        IEnumerable<AttendanceDTO> GetAll();
        AttendanceDTO GetById(int id);
        void Create(AttendanceDTO item);
        void Update(AttendanceDTO item);
        void Delete(int id);
    }
}
