using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.DB;

namespace BackEndAPI.src.Repositorys
{
    public class ProductImageRepository<TModel, TKey> : BaseRepository<TModel, TKey>, IRepository<TModel, TKey> where TModel : class, IData<TKey>
    {
        public ProductImageRepository(DataContext context, IUserContextService userContextService) : base(context, userContextService) { }
    }
}