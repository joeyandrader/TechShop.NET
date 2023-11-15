using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.DB;

namespace BackEndAPI.src.Base.Contracts.Repository
{
    public interface IRepository<TModel, TKey> where TModel : class, IData<TKey>
    {
        DataContext _context { get; }

        /// <summary>
        /// Busca um Registro Especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> Get(TKey id);

        /// <summary>
        /// Cria um novo registro
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        Task<TModel> Create(TModel createDTO);

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        Task<TModel> Update(TKey id, TModel updateDTO);

        /// <summary>
        /// Deleta um registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(TKey id);

        /// <summary>
        /// Lista os registros
        /// </summary>
        /// <returns></returns>
        Task<List<TModel>> List();
    }
}