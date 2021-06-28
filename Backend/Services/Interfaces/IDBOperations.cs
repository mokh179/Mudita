using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IDBOperations<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetbyId(string id);
        Task<T> Add(T t1);
        Task<Boolean> Delete(string id);
        Task<T> Edit(T t1);
        Task<List<T>> SelCityByCountryID(int id);
    }
    
}
