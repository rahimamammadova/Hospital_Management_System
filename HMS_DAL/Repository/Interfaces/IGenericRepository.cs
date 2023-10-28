using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<T> GetById(int id);
        Task<List<T>> GetList();
        Task<T> Create(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
    }
}
