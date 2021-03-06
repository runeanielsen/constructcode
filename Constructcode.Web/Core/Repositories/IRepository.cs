﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Constructcode.Web.Core.Repositories
{
    public interface IRepository<TEntitiy> where TEntitiy : class
    {
        IEnumerable<TEntitiy> GetAll();
        IEnumerable<TEntitiy> Find(Expression<Func<TEntitiy, bool>> predicate);

        TEntitiy SingleOrDefault(Expression<Func<TEntitiy, bool>> predicate);

        void Add(TEntitiy entity);
        void AddRange(IEnumerable<TEntitiy> entities);

        void Update(TEntitiy entity);

        void Remove(TEntitiy entity);
        void RemoveRange(IEnumerable<TEntitiy> entities);
    }
}
