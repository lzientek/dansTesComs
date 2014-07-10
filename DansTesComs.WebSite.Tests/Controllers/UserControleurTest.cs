using System;
using System.Web.Mvc;
using DansTesComs.WebSite.Controllers;
using DansTesComs.WebSite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.WebSite.Tests.Controllers
{
    [TestClass]
    public class UserControleurTest
    {
        [TestMethod]
        public void Index()
        {
            var usercontroleur = new UserController();
            var result = usercontroleur.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
