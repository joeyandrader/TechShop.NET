using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;

namespace BackEndAPI.src.Services
{
    public class BaseService<TModel, TKey> : IService<TModel, TKey> where TModel : class, IData<TKey>
    {
        private readonly IRepository<TModel, TKey> _repository;
        public BaseService(IRepository<TModel, TKey> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TModel> Create(TModel createDTO)
        {
            return await _repository.Create(createDTO);
        }

        public virtual async Task<bool> Delete(TKey id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<TModel> Get(TKey id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task<List<TModel>> List()
        {
            return await _repository.List();
        }

        public virtual async Task<TModel> Update(TKey id, TModel updateDTO)
        {
            return await _repository.Update(id, updateDTO);
        }
    }
}