using PracticeAppData.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppData.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbSet<T> EntitySet { get; set; }
        protected PracticeDBEntities Context { get; set; }

        public GenericRepository(PracticeDBEntities context)
        {
            Context = context;
            EntitySet = Context.Set<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return EntitySet.AsQueryable<T>();
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            list = EntitySet.ToList();
            return list;
        }

        public List<T> GetList(Func<T, bool> where)
        {
            List<T> list = new List<T>();
            list = EntitySet.Where(where).ToList();
            return list;
        }

        public T GetSingle(Func<T, bool> where)
        {
            return EntitySet.FirstOrDefault(where);
        }

        public T Insert(T entity)
        {
            EntitySet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public int Delete(Func<T, bool> where, T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }
            EntitySet.Remove(entity);
            return Context.SaveChanges();
        }

        public T Update(Func<T, bool> where, T entity)
        {
            T obj = GetSingle(where);
            Context.Entry(obj).CurrentValues.SetValues(entity);
            Context.SaveChanges();
            return obj;

        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;

        }

        public List<T> UpdateMany(List<T> entities)
        {
            foreach (var item in entities)
            {
                Context.Entry(item).State = EntityState.Modified;
            }

            Context.SaveChanges();
            return entities;
        }


        public T InsertOrUpdate(Func<T, bool> where, T entity)
        {
            T obj = GetSingle(where);
            if (obj == null)
            {
                EntitySet.Add(entity);
                obj = entity;
            }
            else
            {
                Context.Entry(obj).CurrentValues.SetValues(entity);
                Context.Entry(obj).State = EntityState.Modified;
            }

            Context.SaveChanges();
            return obj;
        }

        public int UpdateProperty(Func<T, bool> where, KeyValuePair<string, object> set)
        {
            T obj = GetSingle(where);
            Context.Entry(obj).Property(set.Key).CurrentValue = set.Value;
            return Context.SaveChanges();
        }

        public int UpdateProperties(Func<T, bool> where, KeyValuePair<string, object> set1, KeyValuePair<string, object> set2, KeyValuePair<string, object> set3, KeyValuePair<string, object> set4)
        {
            T obj = GetSingle(where);
            Context.Entry(obj).Property(set1.Key).CurrentValue = set1.Value;
            Context.Entry(obj).Property(set2.Key).CurrentValue = set2.Value;
            Context.Entry(obj).Property(set2.Key).CurrentValue = set3.Value;
            Context.Entry(obj).Property(set2.Key).CurrentValue = set4.Value;

            return Context.SaveChanges();
        }


        public int UpdatePropertyDecimal(Func<T, bool> where, KeyValuePair<string, object> set)
        {
            T obj = GetSingle(where);
            Context.Entry(obj).Property(set.Key).CurrentValue = Convert.ToDouble(set.Value);
            return Context.SaveChanges();
        }

        public int UpdatePropertyForList(Func<T, bool> where, KeyValuePair<string, object> set)
        {
            List<T> lst = GetList(where);
            foreach (var obj in lst)
            {
                Context.Entry(obj).Property(set.Key).CurrentValue = set.Value;
            }
            return Context.SaveChanges();
        }

        public bool IsExist(Func<T, bool> where)
        {
            return EntitySet.Any(where);
        }
    }
}
