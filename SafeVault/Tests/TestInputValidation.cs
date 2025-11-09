using NUnit.Framework;
using SafeVault.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestInputValidation
    {
        private SafeVaultController controller;

        [SetUp]
        public void Setup() => controller = new SafeVaultController();

        [Test]
        public void TestForSQLInjection()
        {
            var result = controller.Submit("' OR 1=1 --", "test@example.com");
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void TestForXSS()
        {
            var result = controller.Submit("<script>alert('xss')</script>", "test@example.com");
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }
}
