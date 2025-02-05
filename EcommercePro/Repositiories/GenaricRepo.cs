﻿using EcommercePro.Models;
using EcommercePro.Repositiories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace EcommercePro.Repositories
{
    public class GenericRepo<T> : IGenaricService<T> where T : class
    {
        private Context _dbContext;

        public GenericRepo(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            Save();
        }


        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public bool Update(int id, T entity)
        {
            T existingEntity = _dbContext.Set<T>().Find(id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            T existingEntity = _dbContext.Set<T>().Find(id);

            if (existingEntity != null && existingEntity is Product)
            {
               Product product = existingEntity as Product;
                if (product != null)
                {
                    product.IsDeleted = true;
                    this._dbContext.SaveChanges();

                    return true;

                }
            }
            else if (existingEntity != null && existingEntity is Category)
            {
                Category category = existingEntity as Category;
                if (category != null)
                {
                    category.IsDeleted = true;
                    this._dbContext.SaveChanges();
                    return true;
                }


            }
            return false;
        }
    }
}