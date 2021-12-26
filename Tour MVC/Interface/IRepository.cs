using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tour_MVC.Interface
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Exist(string cccd);
        bool Update(T entity);
        bool Delete(int id);
        T findById(string cccd);
        List<T> getAll();
    }
}
