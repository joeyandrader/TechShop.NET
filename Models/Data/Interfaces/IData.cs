using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.src.Base.DB;

namespace BackEndAPI.Models.Data.Interfaces
{
    public interface IData<T>
    {
        T Id { get; set; }

        IQueryable<TModel> DefaultQuery<TModel>(DataContext dbContext, int? userId);
    }
}