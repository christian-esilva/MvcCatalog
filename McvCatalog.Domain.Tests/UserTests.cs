using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcCatalog.Domain;

namespace McvCatalog.Domain.Tests
{
    [TestClass]
    public class Dado_um_novo_usuario
    {
        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_nome()
        {
            var user = new User("","chris@chris.com","chris","bolsomito");
        }

        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_email()
        {
            var user = new User("christian", "", "chris", "bolsomito");
        }

        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_username()
        {
            var user = new User("christian", "chris@chris.com", "", "bolsomito");
        }

        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_uma_senha()
        {
            var user = new User("christian", "chris@chris.com", "chris", "");
        }
    }
}
