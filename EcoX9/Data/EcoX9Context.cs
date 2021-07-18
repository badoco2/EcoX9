using EcoX9.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoX9.Data
{
    public class EcoX9Context : DbContext
    {

        public EcoX9Context(DbContextOptions<EcoX9Context> options) : base(options) { }

        public DbSet<Usuarios> tb_usuarios { get; set; }
        public DbSet<Ocorrencias> tb_ocorrencias { get; set; }
    }
}
