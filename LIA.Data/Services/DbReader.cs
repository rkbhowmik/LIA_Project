using LIA.Data.Data;
using LIA.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LIA.Data.Services
{
    public class DbReader : IDbReader
    {
         private CourseContext _db;
         public DbReader (CourseContext db)
        {
            _db = db;
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

        public async Task<TEntity> Get<TEntity>(int id) where TEntity : class
        {
            return await _db.FindAsync<TEntity>(id);
        }

        public TEntity Get<TEntity>(string userId, int id) where TEntity : class
        {
            return _db.Set<TEntity>().Find(new object[] { userId, id });
        }

        public User Get(string userId)
        {
            return _db.Set<User>().Find(new object[] { userId });
        }

        public List<Course> GetCourses(string userId)
        {
            var courses =
                from uc in _db.UserCourses
                join course in _db.Courses on uc.CourseId equals course.Id
                where uc.UserId == userId
                select course;

            return courses.ToList();
        }

        public SelectList GetSelectList<TEntity>(string valueField, string textField) where TEntity : class
        {
            var items = Get<TEntity>();
            return new SelectList(items, valueField, textField);
        }

        public IEnumerable<TEntity> GetWithIncludes<TEntity>() where TEntity : class
        {
            //Get all names
            var entityNames = GetEntityNames<TEntity>();

            //Access to CourseContext 
            var dbset = _db.Set<TEntity>();

            //Merge the names of the entities
            var entities = entityNames.collections.Union(entityNames.references);

            //Loop through entities and load all name entities

            foreach (var entity in entities)
                _db.Set<TEntity>().Include(entity).Load();

            return dbset;
        }

        private (IEnumerable<string> collections, IEnumerable<string> references) GetEntityNames<TEntity>() where TEntity : class
        {
            // Brings all DBset properties from CourseContext
          
                var dbsets = typeof(CourseContext)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(z => z.PropertyType.Name.Contains("DbSet"))
                .Select(z => z.Name);

            // Get the names of all the properties (tables) in the generic
            // type T that is represented by a DbSet
            var properties = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var collections = properties
                .Where(l => dbsets.Contains(l.Name))
                .Select(s => s.Name);

            var classes = properties
                .Where(c => dbsets.Contains(c.Name + "s"))
                .Select(s => s.Name);

            return (collections: collections, references: classes);
        }
    }
}
