using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clg17042.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(string param);
    }
}
