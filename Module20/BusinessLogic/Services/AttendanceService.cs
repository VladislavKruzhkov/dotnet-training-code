using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BusinessLogic.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly Func<AcademicPerformanceType, IAcademicPerformanceCheckerService> _serviceAccessor;

        private readonly IRepository<Attendance> _repo;

        private readonly IMapper _mapper;

        public AttendanceService(IRepository<Attendance> attendanceRepo, IMapper mapper, Func<AcademicPerformanceType, IAcademicPerformanceCheckerService> serviceAccessor)
        {
            _repo = attendanceRepo;
            _mapper = mapper;
            _serviceAccessor = serviceAccessor;
        }

        public IEnumerable<AttendanceDTO> GetAll()
        {
            var attendance = _repo.GetAll().Select(_mapper.Map<AttendanceDTO>);
            return attendance;
        }

        public AttendanceDTO GetById(int id) => _mapper.Map<AttendanceDTO>(_repo.Get(id));

        public void Create(AttendanceDTO item)
        {
            var attendance = new Attendance
            {
                AttendanceId = item.AttendanceId,
                Date = item.Date,
                StudentId = item.StudentId,
                SubjectId = item.SubjectId,
                IsStudentOnLecture = item.IsStudentOnLecture,
                Mark = item.Mark
            };
            _repo.Create(attendance);
            _serviceAccessor(AcademicPerformanceType.Attendance).CheckStudentAcademicPerformance(attendance.StudentId, attendance.SubjectId);
            _serviceAccessor(AcademicPerformanceType.AverageMark).CheckStudentAcademicPerformance(attendance.StudentId, attendance.SubjectId);
        }

        public void Update(AttendanceDTO attendanceDto)
        {
            var attendance = new Attendance
            {
                AttendanceId = attendanceDto.AttendanceId,
                Date = attendanceDto.Date,
                StudentId = attendanceDto.StudentId,
                SubjectId = attendanceDto.SubjectId,
                IsStudentOnLecture = attendanceDto.IsStudentOnLecture,
                Mark = attendanceDto.Mark
            };
            _repo.Update(attendance);
            _serviceAccessor(AcademicPerformanceType.Attendance).CheckStudentAcademicPerformance(attendance.StudentId, attendance.SubjectId);
            _serviceAccessor(AcademicPerformanceType.AverageMark).CheckStudentAcademicPerformance(attendance.StudentId, attendance.SubjectId);
        }

        public void Delete(int id)
        {
            var attendance = _repo.Get(id);
            if (attendance != null) _repo.Delete(id);
        }
    }
}