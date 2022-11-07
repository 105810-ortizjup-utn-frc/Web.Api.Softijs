using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Controllers;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Tests.ControllerTests
{
    public class RegisterUserControllerTest
    {
        private readonly Mock<IServicioRegister> _mockServicio;
        private RegisterController _registerController;

        public RegisterUserControllerTest()
        {
            _mockServicio = new Mock<IServicioRegister>();
        }

        [SetUp]
        public void Setup()
        {
            _registerController = new RegisterController(_mockServicio.Object);
        }

        [Test]
        public async Task PostRegister_Retorna_Ok()
        {
            //Arrange
            _mockServicio.Setup(x => x.PostRegister(It.IsAny<Usuario>())).Returns(Task.FromResult(new ResultadoBase { CodigoEstado = 200, Error = string.Empty, Message = string.Empty, Ok = true, Resultado = null }));

            var nuevousuario = new ComandoRegister { Apellido = "Ortiz", Contrasenia = "123123", Email = "ortizjup@gmial.com", Legajo = "105810", Nombre = "Pedro" };

            //Act
            var result = await _registerController.PostRegister(nuevousuario);

            //Assert
            Assert.IsTrue(((result.Result as OkObjectResult).Value as ResultadoBase).Ok);
        }

        [Test]
        public async Task PostRegister_Retorna_Not_Ok()
        {
            //Arrange
            _mockServicio.Setup(x => x.PostRegister(It.IsAny<Usuario>())).Returns(Task.FromResult(new ResultadoBase { CodigoEstado = 400, Error = string.Empty, Message = string.Empty, Ok = false, Resultado = null }));

            var usuario = new ComandoRegister { Apellido = "Ortiz", Contrasenia = "123123", Email = string.Empty, Legajo = "105810", Nombre = "Pedro" };

            //Act
            var result = await _registerController.PostRegister(usuario);

            //Assert
            Assert.IsFalse(((result.Result as OkObjectResult).Value as ResultadoBase).Ok);
        }

        [Test]
        public async Task PutUsuario_Retorna_Ok()
        {
            //Arrange
            _mockServicio.Setup(x => x.PutUsuario(It.IsAny<Usuario>())).Returns(Task.FromResult(new ResultadoBase { CodigoEstado = 200, Error = string.Empty, Message = string.Empty, Ok = true, Resultado = null }));

            var usuario = new ComandoPutUsuario { Apellido = "Ortiz", ContraseniaActual = "1231234", ContraseniaNuevo = "123456", Email = string.Empty, Legajo = "105810", Nombre = "Pedro" };

            //Act
            var result = await _registerController.PutUsuario(usuario);

            //Assert
            Assert.IsTrue(((result.Result as OkObjectResult).Value as ResultadoBase).Ok);
        }

        [Test]
        public async Task PutUsuario_Retorna_Not_Ok()
        {
            //Arrange
            _mockServicio.Setup(x => x.PutUsuario(It.IsAny<Usuario>())).Returns(Task.FromResult(new ResultadoBase { CodigoEstado = 400, Error = string.Empty, Message = string.Empty, Ok = false, Resultado = null }));

            var usuario = new ComandoPutUsuario { Apellido = "Ortiz", ContraseniaActual = "1231234", ContraseniaNuevo = "123456", Email = string.Empty, Legajo = "105810", Nombre = "Pedro" };

            //Act
            var result = await _registerController.PutUsuario(usuario);

            //Assert
            Assert.IsFalse(((result.Result as OkObjectResult).Value as ResultadoBase).Ok);
        }
    }
}