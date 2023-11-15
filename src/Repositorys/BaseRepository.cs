using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.DB;
using BackEndAPI.src.Base.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.src.Repositorys
{
    public class BaseRepository<TModel, TKey> : IRepository<TModel, TKey> where TModel : class, IData<TKey>
    {
        public DataContext _context { get; private set; }
        public IQueryable<TModel> DefaultQuery { get; private set; }
        private readonly IUserContextService _userContextService;

        public BaseRepository(DataContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
            var model = Activator.CreateInstance(typeof(TModel)) as IData<TKey>;
            DefaultQuery = model.DefaultQuery<TModel>(_context, _userContextService.GetUserContextData()?.Id);
        }

        public virtual async Task<TModel> Create(TModel createDTO)
        {
            _context.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }

        public virtual async Task<bool> Delete(TKey id)
        {
            var dados = await _context.Set<TModel>().FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (dados == null)
                return false;
            _context.Remove(dados);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public virtual async Task<TModel> Get(TKey id)
        {
            return await DefaultQuery.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<TModel>> List()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public virtual async Task<TModel> Update(TKey id, TModel updateDTO)
        {
            var newObject = await DefaultQuery.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (newObject == null)
            {
                throw new Exception("Não é possivel fazer alteração, verifique os dados passado!");
            }
            updateDTO.ChangePropertyValue("UpdatedAt", DateTime.UtcNow);
            newObject = GenericMap.MapTo(newObject, updateDTO);
            await _context.SaveChangesAsync();
            return newObject;
        }
    }
}