using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.DB;
using BackEndAPI.src.Base.Utilities;

namespace BackEndAPI.Models.Data
{
    public class Category : DateTimeEntity, IData<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        #region Relationship
        [XmlIgnore]
        [JsonIgnore]
        public Product? Product { get; set; }
        #endregion

        #region Query
        public IQueryable<TModel> DefaultQuery<TModel>(DataContext dbContext, int? userId)
        {
            return (from a in dbContext.Category
                    select a).Cast<TModel>();
        }
        #endregion
    }
}