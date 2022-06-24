using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Contracts
{
    public interface IVwRepository<TEntity> where TEntity : class
    {
        //DbQuery<TEntity> Entities { get; }
        //IQueryable<TEntity> Table { get; }
        //IQueryable<TEntity> TableNoTracking { get; }
    }
}
