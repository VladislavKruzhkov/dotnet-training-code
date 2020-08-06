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
    public class StudentRepository : IRepository<Student>
    {
        private DataBaseContext db;

        private readonly ILogger _logger;

        public StudentRepository(DataBaseContext context, ILoggerFactory loggerFactory)
        {
            db = context;
            _logger = loggerFactory.CreateLogger<StudentRepository>();
        }

        public IEnumerable<Student> GetAll()
        {
            _logger.LogInformation("Getting students list from database");
            return db.Students;
        }

        public Student Get(int id)
        {
            _logger.LogInformation($"Getting student with id {id} from database");
            return db.Students.FirstOrDefault(x => x.StudentId == id);
        }
        
        public void Create(Student item)
        {
            _logger.LogInformation("Adding student to database");
            db.Students.Add(item);
            db.SaveChanges();
        }

        public void Update(Student item)
        {
            var student = db.Students.Find(item.StudentId);

            student.Name = item.Name;
            student.Surname = item.Surname;

            db.Entry(student).State = EntityState.Modified;
            _logger.LogInformation("Updating student in database");
            db.SaveChanges();
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            _logger.LogInformation("Finding student in database");
            return db.Students.Include(s=>s.Attendance).Where(predicate);
        }

        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
            {
                _logger.LogInformation("Removing student from database");
                db.Students.Remove(student);
            }
            db.SaveChanges();
        }
    }
}
