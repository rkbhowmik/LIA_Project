﻿using LIA.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    }
}
