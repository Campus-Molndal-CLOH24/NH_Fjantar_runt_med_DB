using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.Core
{
    // Interface for CRUD operations
    public interface ICrudRepository<T>
    {
        Task CreateAsync(T entity);
        Task<T?> ReadAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
