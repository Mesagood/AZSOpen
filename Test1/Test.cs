using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AZS;

namespace Test1
{
    [TestClass]
    public class Test
    {
        АЗСEntities db = new АЗСEntities();

        [TestMethod]
        public void TestAddRole()
        {
            AZS.AddRoleWindow page = new AZS.AddRoleWindow();
            Assert.IsTrue(page.AddRole("kek"));
        }


        [TestMethod]
        public void TestDelRole()
        {
            AZS.DirectorWindow page = new AZS.DirectorWindow();
            Assert.IsTrue(page.deleteRole(10));
        }


        [TestMethod]
        public void TestAddUser()
        {
            AZS.InsertUserWindow page = new AZS.InsertUserWindow();
            Assert.IsTrue(page.AddUser("kek", "kek", "kek", "kek", "kek", 2));
        }


        [TestMethod]
        public void TestDeliteUser()
        {
            AZS.DirectorWindow page = new AZS.DirectorWindow();
            Assert.IsTrue(page.DeliteUser(26));
        }


        [TestMethod]
        public void AddNewSupplier()
        {
            AZS.InsertNewSupplierWindow page = new AZS.InsertNewSupplierWindow();
            Assert.IsTrue(page.AddSupplier("kek", 88005553535, "Kek@mail.ru"));
        }


        [TestMethod]
        public void TestDeliteSupplier()
        {
            AZS.DirectorWindow page = new AZS.DirectorWindow();
            Assert.IsTrue(page.DeliteSupplier(11));
        }
    }
}
