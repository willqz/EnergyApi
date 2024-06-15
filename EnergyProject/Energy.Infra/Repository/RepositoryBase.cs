using Energy.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.Infra.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IGenericsBase<TEntity> where TEntity : class
    {
        private DbContextOptionsBuilder<Context.Context> _OptionsBuilder;

        public RepositoryBase()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<Context.Context>();
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

        public void Add(TEntity t)
        {
            using (Context.Context _db = new Context.Context())
            {
                _db.Add(t);
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (Context.Context _db = new Context.Context())
            {
                var obj = _db.Set<TEntity>().Find(id);
                _db.Remove(obj);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> GetAll()
        {
            Context.Context _db = new Context.Context();
            return _db.Set<TEntity>();
        }

        public TEntity GetById(int Id)
        {
            Context.Context _db = new Context.Context();
            var obj = _db.Set<TEntity>().Find(Id);
            return obj;
        }

        public void Update(TEntity t)
        {
            using (Context.Context _db = new Context.Context())
            {
                _db.Update(t);
                _db.SaveChanges();
            }
        }

        private void Dispose(bool Status)
        {
            if (!Status)
                return;
        }
    }
}
