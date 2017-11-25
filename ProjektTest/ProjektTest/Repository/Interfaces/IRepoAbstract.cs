using ProjektTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTest.Repository.Interfaces
{
    public interface IRepoAbstract <T> where T:class
    { 
        void Create(T entity);
        void Update(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> drugaExpr);
        void Delete(T entity);
    }
}
