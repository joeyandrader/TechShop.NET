using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;

namespace BackEndAPI.src.Services
{
    public class CategoryService<TModel, TKey> : BaseService<TModel, TKey>, IService<TModel, TKey> where TModel : class, IData<TKey>
    {
        public CategoryService(IRepository<TModel, TKey> repository) : base(repository) { }
    }
}