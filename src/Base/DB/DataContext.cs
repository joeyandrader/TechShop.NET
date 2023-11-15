using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.src.Base.DB
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }

        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        //DbSet

        public DbSet<Usuario> Usuarios { get; set; }
    }
}