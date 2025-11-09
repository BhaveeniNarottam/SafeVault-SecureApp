using NUnit.Framework;
using SafeVault.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuth
    {
        private AuthController controller;

        [SetUp]
        public void Setup() => controller = new AuthController();

        [Test]
        public void TestInvalidLogin()
        {
            var result = controller.Login("wrongUser", "wrongPass");
            Assert.IsInstanceOf<UnauthorizedResult>(result);
        }

        [Test]
        public void TestAdminAccessDeniedForUser()
        {
            controller.HttpContext.Session.SetString("Role", "user");
            var result = controller.Dashboard();
            Assert.IsInstanceOf<ForbidResult>(result);
        }
    }
}
