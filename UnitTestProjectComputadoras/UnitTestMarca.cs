using BackendComputadoras.DomainService;
using BackendComputadoras.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectComputadoras
{
    [TestClass]
   public class UnitTestMarca
    {
        [TestMethod]
        public void ValidarNombreMarcaAlRegistrar()
        {
            MarcaDomainService marcaomainService = new MarcaDomainService();
            Marca marca = new Marca();
            marca.nombre = "";

            var respuesta = marcaomainService.RegistrarMarca(marca);

            Assert.AreEqual("Se requiere el nombre de la marca.", respuesta);
        }

        [TestMethod]
        public void ValidaraAnioMarcaAlRegistrar()
        {
            MarcaDomainService marcaomainService = new MarcaDomainService();
            Marca marca = new Marca();
            marca.anio = "";

            var respuesta = marcaomainService.RegistrarMarca(marca);

            Assert.AreEqual("Se requiere del año.", respuesta);
        }

        [TestMethod]
        public void ValidarNombreAlModificar()
        {
            MarcaDomainService marcaomainService = new MarcaDomainService();
            Marca marca = new Marca();
            int id = 1;
            marca.nombre = "";

            var respuesta = marcaomainService.ActualizarMarca(id, marca);

            Assert.AreEqual("Se requiere el nombre de la marca.", respuesta);
        }

        [TestMethod]
        public void ValidaraAnioMarcaAlModificar()
        {
            MarcaDomainService marcaomainService = new MarcaDomainService();
            Marca marca = new Marca();
            int id = 1;
            marca.anio = "";

            var respuesta = marcaomainService.ActualizarMarca(id, marca);

            Assert.AreEqual("Se requiere del año.", respuesta);
        }
    }
}
