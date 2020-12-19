using BackendComputadoras.DomainService;
using BackendComputadoras.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectComputadoras
{
    [TestClass]
    public class UnitTestComputadora
    {
        [TestMethod]
        public void ValidarNombreComputadoraAlRegistrar()
        {
            ComputadoraDomainService computadoraDomainService = new ComputadoraDomainService();
            Computadora computadora = new Computadora();
            computadora.nombre = "";

            var respuesta = computadoraDomainService.RegistrarComputadora(computadora);

            Assert.AreEqual("Se requiere el nombre de la computadora.", respuesta);
        }

        [TestMethod]
        public void ValidarTipoDiscoComputadoraAlRegistrar()
        {
            ComputadoraDomainService computadoraDomainService = new ComputadoraDomainService();
            Computadora computadora = new Computadora();
            computadora.tipoDisco = "";

            var respuesta = computadoraDomainService.RegistrarComputadora(computadora);

            Assert.AreEqual("Se requiere del tipo de disco.", respuesta);
        }

        [TestMethod]
        public void ValidarPrecioComputadoraAlRegistrar()
        {
            ComputadoraDomainService computadoraDomainService = new ComputadoraDomainService();
            Computadora computadora = new Computadora();
            computadora.precio = "";

            var respuesta = computadoraDomainService.RegistrarComputadora(computadora);

            Assert.AreEqual("Se requiere el precio.", respuesta);
        }

        [TestMethod]
        public void ValidarNombreComputadoraAlModificar()
        {
            ComputadoraDomainService computadoraDomainService = new ComputadoraDomainService();
            Computadora computadora = new Computadora();
            Marca marca = new Marca();
            int id = 1;
            computadora.nombre = "";

            var respuesta = computadoraDomainService.ActualizarComputadora(id, computadora, marca);

            Assert.AreEqual("Se requiere el nombre de la computadora.", respuesta);
        }

        [TestMethod]
        public void ValidarTipoDiscoComputadoraAlModificar()
        {
            ComputadoraDomainService computadoraDomainService = new ComputadoraDomainService();
            Computadora computadora = new Computadora();
            Marca marca = new Marca();
            int id = 1;
            computadora.tipoDisco = "";

            var respuesta = computadoraDomainService.ActualizarComputadora(id, computadora, marca);

            Assert.AreEqual("Se requiere del tipo de disco.", respuesta);
        }

        [TestMethod]
        public void ValidarPrecioComputadoraAlModificar()
        {
            ComputadoraDomainService computadoraDomainService = new ComputadoraDomainService();
            Computadora computadora = new Computadora();
            Marca marca = new Marca();
            int id = 1;
            computadora.precio = "";

            var respuesta = computadoraDomainService.ActualizarComputadora(id, computadora, marca);

            Assert.AreEqual("Se requiere el precio.", respuesta);
        }
    }
}
