using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.DataAccess;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataLayer.Repositories
{
    public class AttendanceRepository : IRepository<Attendance>
    {
        private DataBaseContext db;

        private readonly ILogger _logger;

        public AttendanceRepository(DataBaseContext context, ILoggerFactory loggerFactory)
        {
            db = context;
            _logger = loggerFactory.CreateLogger<AttendanceRepository>();
        }

        public IEnumerable<Attendance> GetAll()
        {
            _logger.LogInformation("Getting attendance list from database");
            return db.Attendance;
        }

        public Attendance Get(int id)
        {
            _logger.LogInformation($"Getting attendance with id {id} from database");
            return db.Attendance.Find(id);
        }

        public void Create(Attendance item)
        {
            _logger.LogInformation("Adding attendance to database");
            db.Attendance.Add(item);
            db.SaveChanges();
        }

        public void Update(Attendance item)
        {
            var attendance = db.Attendance.Find(item.AttendanceId);

            attendance.StudentId = item.StudentId;
            attendance.SubjectId = item.SubjectId;
            attendance.Date = item.Date;
            attendance.Mark = item.Mark;
            attendance.IsStudentOnLecture = item.IsStudentOnLecture;

            db.Entry(attendance).State = EntityState.Modified;
            _logger.LogInformation("Updating attendance in database");
            db.SaveChanges();
        }

        public IEnumerable<Attendance> Find(Func<Attendance, bool> predicate)
        {
            _logger.LogInformation("Finding attendance in database");
            return db.Attendance.Where(predicate);
        }

        public void Delete(int id)
        {
            Attendance attendance = db.Attendance.Find(id);
            if (attendance != null)
            {
                _logger.LogInformation("Removing attendance from database");
                db.Attendance.Remove(attendance);
            }
            db.SaveChanges();
        }
    }
}
