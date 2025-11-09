using NUnit.Framework;
using SafeVault.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestSecurity
    {
        private SafeVaultController controller;

        [SetUp]
        public void Setup() => controller = new SafeVaultController();

        [Test]
        public void TestSQLInjectionBlocked()
        {
            var result = controller.Submit("' OR 1=1 --", "test@example.com");
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void TestXSSBlocked()
        {
            var result = controller.Submit("<script>alert('xss')</script>", "test@example.com");
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }
}
