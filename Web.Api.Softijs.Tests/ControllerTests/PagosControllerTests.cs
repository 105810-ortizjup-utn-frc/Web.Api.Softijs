using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Controllers;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Services.Pagos;

namespace Web.Api.Softijs.Tests.ControllerTests
{
    public class PagosControllerTests
    {
        private readonly Mock<IServicioPagos> _mockServicio;
        private PagosController _pagosController;

        public PagosControllerTests()
        {
            _mockServicio = new Mock<IServicioPagos>();
        }

        [SetUp]
        public void Setup()
        {
            _pagosController = new PagosController(_mockServicio.Object);
        }

        [Test]
        public void GetOrdenP_Retorna_Ordenes()
        {
            //Arrange
            _mockServicio.Setup(x => x.GetOrdenP()).Returns(Task.FromResult(new List<DTOordenP> { new DTOordenP { NroOrden = 1 } }));

            //Act
            var result = _pagosController.GetOrdenP();

            //Assert
            Assert.IsTrue(((result.Result as OkObjectResult).Value as List<DTOordenP>).Any());
        }

        [Test]
        public void GetOrdenP_No_Retorna_Ordenes()
        {
            //Arrange
            _mockServicio.Setup(x => x.GetOrdenP()).Returns(Task.FromResult(new List<DTOordenP>()));

            //Act
            var result = _pagosController.GetOrdenP();

            //Assert
            Assert.IsFalse(((result.Result as OkObjectResult).Value as List<DTOordenP>).Any());
        }

        [Test]
        public void GetDetallesOrdenesPago_Retorna_Ordenes()
        {
            //Arrange
            _mockServicio.Setup(x => x.GetDetallesOrdenesPago()).Returns(Task.FromResult(new List<DTODetalleOrdenPago>() { new DTODetalleOrdenPago { } }));

            //Act
            var result = _pagosController.GetDetallesOrdenesPago();

            //Assert
            Assert.IsTrue(((result.Result as OkObjectResult).Value as List<DTODetalleOrdenPago>).Any());
        }

        [Test]
        public void GetDetallesOrdenesPago_No_Retorna_Ordenes()
        {
            //Arrange
            _mockServicio.Setup(x => x.GetDetallesOrdenesPago()).Returns(Task.FromResult(new List<DTODetalleOrdenPago>()));

            //Act
            var result = _pagosController.GetDetallesOrdenesPago();

            //Assert
            Assert.IsFalse(((result.Result as OkObjectResult).Value as List<DTODetalleOrdenPago>).Any());
        }
    }
}
