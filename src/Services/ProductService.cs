using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;

namespace BackEndAPI.src.Services
{
    public class ProductService<TModel, TKey> : BaseService<TModel, TKey>, IService<TModel, TKey> where TModel : class, IData<TKey>
    {
        public ProductService(IRepository<TModel, TKey> repository) : base(repository) { }
    }
}