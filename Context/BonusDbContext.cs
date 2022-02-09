using Microsoft.EntityFrameworkCore;
using Bonus.API.Models;
using System;

namespace Bonus.API.Context
{
    public class BonusDbContext : DbContext
    {
        public BonusDbContext(DbContextOptions<BonusDbContext> options) : base(options)
        {
            // CASO NÃO EXISTA A BASE DE DADOS, ENTÃO CRIA
            Database.EnsureCreated();
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        /// <summary>
        /// POPULANDO A BASE DE DADOS COM REGISTROS INICIAS
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(
                new Funcionario { Id = 1, CodigoMatricula = "123", NomeCompleto = "Gordon Gekko", 
                                  AreaAtuacao = "Diretoria", Cargo = "Funcionário", SalarioBruto = 9000, DataAdmissao = Convert.ToDateTime("2002-01-01") },
                new Funcionario { Id = 2, CodigoMatricula = "456", NomeCompleto = "Bud Fox",
                                  AreaAtuacao = "Diretoria", Cargo = "Funcionário", SalarioBruto = 8000, DataAdmissao = Convert.ToDateTime("2008-01-01") },
                new Funcionario { Id = 3, CodigoMatricula = "886", NomeCompleto = "Darien Taylor", 
                                  AreaAtuacao = "Relacionamento com cliente", Cargo = "Funcionário", SalarioBruto = 7000, DataAdmissao = Convert.ToDateTime("2015-01-01") },
                new Funcionario { Id = 4, CodigoMatricula = "658", NomeCompleto = "Kate Gekko",
                                  AreaAtuacao = "Contabilidade", Cargo = "Estagiário", SalarioBruto = 2000, DataAdmissao = Convert.ToDateTime("2020-01-01") },
                new Funcionario { Id = 5, CodigoMatricula = "358", NomeCompleto = "Carl Fox", 
                                  AreaAtuacao = "Financeiro", Cargo = "Funcionário", SalarioBruto = 5000, DataAdmissao = Convert.ToDateTime("2008-01-01") },
                new Funcionario { Id = 6, CodigoMatricula = "873", NomeCompleto = "Roger Bames",
                                  AreaAtuacao = "Tecnologia", Cargo = "Estagiário", SalarioBruto = 1000, DataAdmissao = Convert.ToDateTime("2021-01-01") },
                new Funcionario { Id = 7, CodigoMatricula = "325", NomeCompleto = "Candice Rogers", 
                                  AreaAtuacao = "Serviços gerais", Cargo = "Funcionário", SalarioBruto = 2000, DataAdmissao = Convert.ToDateTime("2020-01-01") },
                new Funcionario { Id = 8, CodigoMatricula = "863", NomeCompleto = "Stone Livingston",
                                  AreaAtuacao = "Tecnologia", Cargo = "Funcionário", SalarioBruto = 4000, DataAdmissao = Convert.ToDateTime("2018-01-01") },
                new Funcionario { Id = 9, CodigoMatricula = "286", NomeCompleto = "Harold Salt", 
                                  AreaAtuacao = "Financeiro", Cargo = "Funcionário", SalarioBruto = 5000, DataAdmissao = Convert.ToDateTime("2017-01-01") },
                new Funcionario { Id = 10, CodigoMatricula = "458", NomeCompleto = "Rudy Gekko",
                                  AreaAtuacao = "Relacionamento com cliente", Cargo = "Estagiário", SalarioBruto = 1000, DataAdmissao = Convert.ToDateTime("2020-01-01") }
            );
        }
    }
}
