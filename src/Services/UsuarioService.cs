using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Utilities;

namespace BackEndAPI.src.Services
{
    public class UsuarioService<TModel, TKey> : BaseService<TModel, TKey>, IService<TModel, TKey> where TModel : class, IData<TKey>
    {
        public UsuarioService(IRepository<TModel, TKey> repository) : base(repository)
        {
        }

        public override Task<TModel> Create(TModel createDTO)
        {
            Usuario request = (Usuario)Convert.ChangeType(createDTO, typeof(Usuario));
            request.Password = request.Password?.GerarHash();
            return base.Create((TModel)Convert.ChangeType(createDTO, typeof(TModel)));
        }
    }
}