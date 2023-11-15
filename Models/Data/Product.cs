using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class Product : DateTimeEntity, IData<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [DefaultValue(0)]
        public ProductStatus Status { get; set; } = ProductStatus.Pendente;

        public decimal? Price { get; set; }

        public string? Brand { get; set; }

        public int Amount { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        #region ForeignKey
        public int? CategoryId { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public Category? Category { get; set; }
        #endregion

        #region Relationship
        [XmlIgnore]
        [JsonIgnore]
        public ProductImage? ProductImage { get; set; }
        #endregion


        #region Query
        public IQueryable<TModel> DefaultQuery<TModel>(DataContext dbContext, int? userId)
        {
            return (from a in dbContext.Product
                    select a).Cast<TModel>();
        }
        #endregion
    }


}