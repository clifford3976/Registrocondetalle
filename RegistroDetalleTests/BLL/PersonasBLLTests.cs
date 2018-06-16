using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDetalle.BLL;
using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroDetalle.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());

            Personas Persona = new Personas();
            Persona.PersonaId = 0;
            Persona.Fecha = DateTime.Now;
            Persona.Nombres = " Jean";
            Persona.Cedula = "540-000-555";
            Persona.Telefono = "829-368-3976";
            Persona.Direccion = "calle salcedo";
            bool paso =repositorio.Guardar(Persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            Personas Persona = new Personas();

            Persona.PersonaId = 0;
            Persona.Fecha = DateTime.Now;
            Persona.Nombres = " Clifford";
            Persona.Cedula = "540-412-555";
            Persona.Telefono = "829-368-3456";
            Persona.Direccion = "calle castillo";
            bool paso = repositorio.Modificar(Persona);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void EliminarTest()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            Personas Persona = new Personas();

            bool paso = repositorio.Eliminar(829-368-3456);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            Personas Persona = new Personas();

            Persona = repositorio.Buscar(829-368-3456);
            Assert.IsNotNull(Persona);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            Personas Persona = new Personas();

            var Lista = repositorio.GetList(x => true);
            Assert.IsNotNull(Lista);
        }
    }
}