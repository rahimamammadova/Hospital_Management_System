using AutoMapper;
using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using HMS_DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Services
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : BaseDto where TEntity : BaseEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;

        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> CreateAsync(TDto entity)
        {
            TEntity item = _mapper.Map<TEntity>(entity);
            item.Created = DateTime.Now;
            var savedItem = await _repository.Create(item);
            return _mapper.Map<TDto>(savedItem);
        }

        public async Task<TDto> DeleteAsync(int id)
        {
            var deletedItem = await _repository.Delete(id);
            return _mapper.Map<TDto>(deletedItem);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var existingItem = await _repository.GetById(id);
            return _mapper.Map<TDto>(existingItem);
        }

        public async Task<List<TDto>> GetListAsync()
        {
            var list = await _repository.GetList();
            return _mapper.Map<List<TDto>>(list);
        }

        public async Task<TDto> UpdateAsync(TDto entity)
        {
            var existingItem = await _repository.GetById(entity.Id);
            var newEntity = _mapper.Map<TEntity>(entity);
            newEntity.Created = existingItem.Created;
            var updatedItem = _repository.Update(newEntity);
            return _mapper.Map<TDto>(updatedItem);
        }
    }
}
