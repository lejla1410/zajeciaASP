using ProjektTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjektTest.Repository
{
    public class RepoAbstract<T> where T:class, IBasicEntity
    {

        //Ta metoda pozwala na stworzenie wiersza
        public virtual void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateCreate = DateTime.Now;
                entity.DateMod = DateTime.Now;
                entity.IsActive = true;
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
        //uaktualnia tabelę
        public virtual void Update(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        // Tworzy  listę z wierszy 
        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var lista = context.Set<T>().Where(expression);
                return lista.ToList();
            }
        }
        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                entity.IsActive = false;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
