using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAllItem();
    }
}
