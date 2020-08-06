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
    public class ProfessorRepository : IRepository<Professor>
    {
        private DataBaseContext db;

        private readonly ILogger _logger;

        public ProfessorRepository(DataBaseContext context, ILoggerFactory loggerFactory)
        {
            db = context;
            _logger = loggerFactory.CreateLogger<ProfessorRepository>();
        }

        public IEnumerable<Professor> GetAll()
        {
            _logger.LogInformation("Getting professors list from database");
            return db.Professors.Include(x => x.Subjects);
        }

        public Professor Get(int id)
        {
            _logger.LogInformation($"Getting professor with id {id} from database");
            return db.Professors.Include(x => x.Subjects).FirstOrDefault(x=>x.ProfessorId == id);
        }

        public void Create(Professor item)
        {
            _logger.LogInformation("Adding professor to database");
            db.Professors.Add(item);
            db.SaveChanges();
        }

        public void Update(Professor item)
        {
            var professor = db.Professors.Find(item.ProfessorId);

            professor.Name = item.Name;
            professor.Surname = item.Surname;

            db.Entry(professor).State = EntityState.Modified;
            _logger.LogInformation("Updating professor in database");
            db.SaveChanges();
        }

        public IEnumerable<Professor> Find(Func<Professor, bool> predicate)
        {
            _logger.LogInformation("Finding professor in database");
            return db.Professors.Where(predicate);
        }

        public void Delete(int id)
        {
            Professor professor = db.Professors.Find(id);
            if (professor != null)
            {
                _logger.LogInformation("Removing professor from database");
                db.Professors.Remove(professor);
            }
            db.SaveChanges();
        }
    }
}

