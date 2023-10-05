﻿using SfdEnerji.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Repository.Shared.Abstract
{
    public interface IRepository< T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>>filter);   
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeLeteById(int id);
        T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T,bool>>filter);

    }
}