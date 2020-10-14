using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjetoTeste.Context;
using ProjetoTeste.Controllers;
using ProjetoTeste.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ProjetoTeste.DTOs;
using ProjetoTeste.Pagination;
using ProjetoTeste.Models;

namespace ProjetoTestexUnit
{
    public class ContratosUnitTestController
    {
        private IMapper mapper;
        private IUnitOfWork repository;

        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        public static string connectionString =
            "Integrated Security=SSPI;Persist Security Info=true;Database=ContratoDB;Server=DESKTOP-RO84DDO\\SQLSERVERHBJ";

        static ContratosUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public ContratosUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            var context = new AppDbContext(dbContextOptions);

            repository = new UnitOfWork(context);

            //testes unitários ====================================================

            // testar método GET
            [Fact]

            void GetContratos_Return_OkResult()
            {
                //Arrange
                var controller = new ContratosController(repository, mapper);

                //Act
                var data = controller.Get();

                //Assert
                Assert.IsType<List<ContratoDTO>>(data.Value);
            }
        }
    }
}
