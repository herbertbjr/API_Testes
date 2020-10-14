using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ProjetoTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Prestacao> Prestacao { get; set; }
    }
}
