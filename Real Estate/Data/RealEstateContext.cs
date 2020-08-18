using Microsoft.EntityFrameworkCore;
using Real_Estate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Data
{
    public class RealEstateContext : DbContext
    {   
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Password=matmau11;Persist Security Info=True;User ID=SQLServerRoot;Initial Catalog=RealEstateDB;Data Source=DESKTOP-QPIN7GD\\SQLEXPRESS",
                providerOptions => providerOptions.CommandTimeout(60));
        }

        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            : base(options)
         { }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Casa> Casas { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }

    }
}
