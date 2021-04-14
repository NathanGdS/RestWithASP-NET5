using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        private DbSet<T> dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            //dinamicamente setando o dataSet em tempo de execuxao
            dataSet = _context.Set<T>();
        }

        public T FindByID(long id)
        {
            return dataSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T Create(T item)
        {

            try
            {
                dataSet.Add(item);
                _context.SaveChanges();

                return item;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(x => x.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }

        public bool Error()
        {
            return true;
        }
    }
}

