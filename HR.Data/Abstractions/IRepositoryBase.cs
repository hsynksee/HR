using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Abstractions
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Create(T entity);
        void Update(T entity);
        Task Delete(int id);

    }
}
