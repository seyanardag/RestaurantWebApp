using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly signalRContext _signalRContext;

        public GenericRepository(signalRContext signalRContext)
        {
            _signalRContext = signalRContext;
        }

        void IGenericDal<T>.Add(T entity)
        {
            _signalRContext.AddAsync(entity);
            _signalRContext.SaveChangesAsync().Wait();
        }

        void IGenericDal<T>.Delete(T entity)
        {
            _signalRContext.Remove(entity);
            _signalRContext.SaveChangesAsync().Wait();

        }

        List<T> IGenericDal<T>.GetAll()
        {
            return _signalRContext.Set<T>().ToList();
        }

        T IGenericDal<T>.GetById(int id)
        {
            var entity = _signalRContext.Set<T>().Find(id);
            if (entity != null) { return entity; }
            else throw new InvalidOperationException("Bu id ile herhangi bir giriş bulunamadı");
        }

        void IGenericDal<T>.Update(T entity)
        {
            _signalRContext.Update(entity);
            _signalRContext.SaveChangesAsync().Wait();

        }
    }
}
