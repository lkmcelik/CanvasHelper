using CanvasHelperServerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CanvasHelperServerApp.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : DatabaseObject
    {
        private readonly CanvasDbContext context;
        private readonly DbSet<T> dbSet;

        public BaseRepository(CanvasDbContext context) {
            
            this.context = context;
            dbSet = this.context.Set<T>();
        }
        public bool AddOrUpdate(T item) {
            try {
                if (item.ID == 0) {
                    dbSet.Add(item);
                }
                else {
                    dbSet.Update(item);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) {

                return false;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null) {
            if (predicate == null) {
                return dbSet.AsQueryable();
            }
            return dbSet.Where(predicate);
        }

        public T GetById(int Id) {
            return dbSet.Find(Id);
        }

        public bool Remove(T item) {
            try {
                dbSet.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false; 
            }
        }
    }
}
