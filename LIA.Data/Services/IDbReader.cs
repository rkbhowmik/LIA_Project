using LIA.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Services
{
    public interface IDbReader
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class;
        
    }
}
