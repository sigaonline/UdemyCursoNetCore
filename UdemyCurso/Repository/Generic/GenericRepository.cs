
using System.Collections.Generic;
using System;
using UdemyCurso.Model.Base;
using UdemyCurso.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UdemyCurso.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dataSet;
        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            try
            {

                var result = _dataSet.SingleOrDefault(p => p.Id.Equals(id));
                if (result != null)
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool Exists(long? id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindBy(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            try
            {
                if (!Exists(item.Id)) return null;

                var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }
    }
}
