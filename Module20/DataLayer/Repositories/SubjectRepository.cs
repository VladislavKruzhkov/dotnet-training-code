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
    public class SubjectRepository : IRepository<Subject>
    {
        private DataBaseContext db;

        private readonly ILogger _logger;

        public SubjectRepository(DataBaseContext context, ILoggerFactory loggerFactory)
        {
            db = context;
            _logger = loggerFactory.CreateLogger<SubjectRepository>();
        }

        public IEnumerable<Subject> GetAll()
        {
            _logger.LogInformation("Getting subjects list from database");
            return db.Subjects;
        }

        public Subject Get(int id)
        {
            _logger.LogInformation($"Getting subject with id {id} from database");
            return db.Subjects.FirstOrDefault(x => x.SubjectId == id);
        }

        public void Create(Subject item)
        {
            _logger.LogInformation("Adding subject to database");
            db.Subjects.Add(item);
            db.SaveChanges();
        }

        public void Update(Subject item)
        {
            var subject = db.Subjects.Find(item.SubjectId);

            subject.Name = item.Name;

            db.Entry(subject).State = EntityState.Modified;
            _logger.LogInformation("Updating professor in database");
            db.SaveChanges();
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            _logger.LogInformation("Finding subject in database");
            return db.Subjects.Include(x => x.Attendance).Where(predicate);
        }

        public void Delete(int id)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject != null)
            {
                _logger.LogInformation("Removing subject from database");
                db.Subjects.Remove(subject);
            }
            db.SaveChanges();
        }
    }
}
