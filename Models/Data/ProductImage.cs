using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.DB;
using BackEndAPI.src.Base.Utilities;

namespace BackEndAPI.Models.Data
{
    public class ProductImage : DateTimeEntity, IData<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? UrlImage { get; set; }
        public int Order { get; set; }

        #region ForeignKey
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        #endregion

        #region Query
        public IQueryable<TModel> DefaultQuery<TModel>(DataContext dbContext, int? userId)
        {
            return (from a in dbContext.ProductImage
                    select a).Cast<TModel>();
        }
        #endregion
    }
}