using HMS_BLL.Dtos;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Services.Interfaces
{
    public interface IGenericService<TDto, TEntity> where TDto : BaseDto where TEntity : BaseEntity, new()
    {
        Task<TDto> GetByIdAsync(int id);
        Task<List<TDto>> GetListAsync();
        Task<TDto> CreateAsync(TDto entity);
        Task<TDto> UpdateAsync(TDto entity);
        Task<TDto> DeleteAsync(int id);

    }
}
