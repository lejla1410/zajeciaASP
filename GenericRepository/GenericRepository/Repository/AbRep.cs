using GenericRepository.Models;
using GenericRepository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GenericRepository.Repository
{
    public class AbRep<D> where D : class
    {
        //Ta metoda pozwala na stworzenie wiersza
        public virtual void Create(D klasa)
        {
            using (var context = new GenDB())
            {
                context.Set<D>().Add(klasa);
                context.SaveChanges();
            }
        }
        //uaktualnia tabelę
        public virtual void Update(D klasa)
        {
            using (var pierwszy = new GenDB())
            {
                pierwszy.Entry(klasa).State = EntityState.Modified;
                pierwszy.SaveChanges();
            }
        }
        // Tworzy  listę z wierszy 
        public virtual List<D> GetWhere(Expression<Func<D, bool>> drugaExpr)
        {
            using (var pierwszy = new GenDB())
            {
                var lista = pierwszy.Set<D>().Where(drugaExpr);
                return lista.ToList();
            }
        }
        public virtual void Delete(D klasa)
        {
            using (var pierwszy = new GenDB())
            {
                if (pierwszy.Entry(klasa).State == EntityState.Detached)
                {
                    pierwszy.Set<D>().Attach(klasa);
                }
                pierwszy.Set<D>().Remove(klasa);
                pierwszy.SaveChanges();
            }

        }
    }
}
