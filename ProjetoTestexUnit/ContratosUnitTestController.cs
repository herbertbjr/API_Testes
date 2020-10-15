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
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

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
        }

        //testes unitários ====================================================

        // testar método GET
        [Fact]
        // OkResult ..
        public void GetContratos_Return_OkResult()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<List<ContratoDTO>>(data.Value);
        }

        [Fact]
        // BadRequest ..
        public void GetContratos_Return_BadRequestResult()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        // GET retornar lista de objetos contrato ..
        public void GetContratos_MatchResult()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<List<ContratoDTO>>(data.Value);
            var ctr = data.Value.Should().BeAssignableTo<List<ContratoDTO>>().Subject;

            Assert.Equal("1", ctr[0].Id.ToString());
            Assert.Equal("10/10/2019 00:00:00", ctr[0].Data.ToString());
            Assert.Equal("3", ctr[0].QtdeParcelas.ToString());
            Assert.Equal("6000,00", ctr[0].VlrFinanciado.ToString());

            Assert.Equal("4", ctr[1].Id.ToString());
            Assert.Equal("15/12/2019 01:00:00", ctr[1].Data.ToString());
            Assert.Equal("20", ctr[1].QtdeParcelas.ToString());
            Assert.Equal("88000,00", ctr[1].VlrFinanciado.ToString());

            Assert.Equal("6", ctr[2].Id.ToString());
            Assert.Equal("15/12/2019 01:00:00", ctr[2].Data.ToString());
            Assert.Equal("20", ctr[2].QtdeParcelas.ToString());
            Assert.Equal("77000,00", ctr[2].VlrFinanciado.ToString());

        }

        // testar Método GetById(int Id)
        [Fact]
        // OkResult ..
        public void GetContratos_Return_OkResultById()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);
            int ctrId = 7;

            //Act
            var data = controller.GetById(ctrId);

            //Assert
            Assert.IsType<ContratoDTO>(data.Value);
        }

        [Fact]
        //// BadRequest ..
        public void GetContratos_Return_BadRequestResultById()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);
            int ctrId = 25;

            //Act
            var data = controller.GetById(ctrId);

            //Assert
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        //// NotFound ..
        public void GetContratos_Return_NotFoundById()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);
            int ctrId = 1111;

            //Act
            var data = controller.GetById(ctrId);

            //Assert
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        // GET retornar lista de objetos contrato ..
        public void GetContratos_MatchResultById()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);
            int ctrId = 7;

            //Act
            var data = controller.GetById(ctrId);

            //Assert
            Assert.IsType<ContratoDTO>(data.Value);
            var ctr = data.Value.Should().BeAssignableTo<ContratoDTO>().Subject;

            Assert.Equal("7", ctr.Id.ToString());
            Assert.Equal("22/09/2019 01:00:00", ctr.Data.ToString());
            Assert.Equal("12", ctr.QtdeParcelas.ToString());
            Assert.Equal("5000,00", ctr.VlrFinanciado.ToString());
        }

        //Testar método Post ..
        [Fact]
        // Post retornar CreatedResult ..
        public void Post_Contrato_ValidaReturn()
        {
            //Arrange
            var controller = new ContratosController(repository, mapper);

            var ctr = new ContratoDTO()
            {
                Data = Convert.ToDateTime("2019-12-15"), QtdeParcelas = 5, VlrFinanciado = 11111
            };

            //Act
            var data = controller.Post(ctr);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(data);
        }
    }
}
