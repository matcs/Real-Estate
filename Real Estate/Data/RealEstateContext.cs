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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proprietario>().HasData(
                new Proprietario
                {
                    cod_proprietario=1,
                    nome_proprietario="Matheus Costa dos Santos",
                    email="matmau11@hotmail.com",
                    senha="matmau11",
                    telefone="954946842"
                },
                new Proprietario
                {
                    cod_proprietario = 2,
                    nome_proprietario = "Mauricio Potter dos Santos",
                    email = "maumau11@hotmail.com",
                    senha = "maumau11",
                    telefone = "986174471"
                },
                new Proprietario
                {
                    cod_proprietario = 3,
                    nome_proprietario = "Dorival Lodbrok",
                    email = "dorivalodbrok@hotmail.com",
                    senha = "doridori11",
                    telefone = "979564471"
                }
            );

            modelBuilder.Entity<Endereco>().HasData(
                new Endereco
                {   
                    cod_endereco=1,
                    logradouro = "Rua",
                    rua = "Silverio Sasso",
                    bairro = "Vila Yara",
                    numero = "463",
                    municipio = "Osasco",
                    estado = "SP",
                    cep = "06026-050"

                },
                new Endereco
                {
                    cod_endereco = 2,
                    logradouro = "Avenida",
                    rua = "dos Remedios",
                    bairro = "Vila dos Remédios",
                    numero = "4561a",
                    municipio = "São Paulo",
                    estado = "SP",
                    cep = "02675-031"

                },
                new Endereco
                {
                    cod_endereco = 3,
                    logradouro = "Rua",
                    rua = "Vista Corona",
                    bairro = "Palm Desert",
                    numero = "75245",
                    municipio = "California",
                    estado = "CA",
                    cep = "92211"

                }

            );

            modelBuilder.Entity<Imovel>().HasData(
                new Imovel
                {
                    cod_imovel = 1,
                    metro_quadrado = 625,
                    descricao = "Lugar agradavel com vista para calçada!",
                    numero_quartos = 4,
                    numero_banheiros = 1,
                    _tipoImovel = 0,
                    ProprietarioRefId = 1,
                    EnderecoRefId = 1


                },
                new Imovel
                {
                    cod_imovel = 2,
                    metro_quadrado = 2550,
                    descricao = "Lindo, apenas.",
                    numero_quartos = 5,
                    numero_banheiros = 2,
                    _tipoImovel = 0,
                    ProprietarioRefId = 2,
                    EnderecoRefId = 2

                },
                new Imovel
                {
                    cod_imovel = 3,
                    metro_quadrado = 400,
                    descricao = "Apartamento com uma varanda linda para o mar!",
                    numero_quartos = 2,
                    numero_banheiros = 1,
                    _tipoImovel = (Enums.TipoImovel)1,
                    ProprietarioRefId = 3,
                    EnderecoRefId = 3

                }
            );

            modelBuilder.Entity<Casa>().HasData(
                new Casa
                {
                    cod_casa = 1,
                    tipo = "HomeTown",
                    quintal = true,
                    garagem = true,
                    numero_vagas = 1,
                    valor_p_metro2 = 25,
                    ImovelRefId = 1
                },
                new Casa
                {
                    cod_casa = 2,
                    tipo = "Duplex",
                    quintal = false,
                    garagem = true,
                    numero_vagas = 1,
                    valor_p_metro2 = 30,
                    ImovelRefId = 2
                }

            );

            modelBuilder.Entity<Apartamento>().HasData(
                new Apartamento
                {
                    cod_apartamento = 1,
                    nome_bloco = "Andorinha",
                    numero_bloco = 9,
                    ImovelRefId = 3
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Casa> Casas { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }

    }
}
