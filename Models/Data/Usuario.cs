using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.DB;
using BackEndAPI.src.Base.Enums;
using BackEndAPI.src.Base.Utilities;

namespace BackEndAPI.Models.Data
{
    public class Usuario : IData<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string? Cpf { get; set; }

        public int? Age { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public string? Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [DefaultValue(0)]
        public AccountType AccountType { get; set; } = AccountType.Usuario;


        #region PasswordHash

        public bool ValidaSenha(string password)
        {
            return Password == password.GerarHash();
        }

        public string GeraPassHash(string password)
        {
            return Password = password.GerarHash();
        }

        #endregion

        #region Query
        public IQueryable<TModel> DefaultQuery<TModel>(DataContext dbContext, int? userId)
        {
            return (from a in dbContext.Usuarios
                    select a).Cast<TModel>();
        }
        #endregion
    }
}