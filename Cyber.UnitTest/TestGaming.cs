using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfCyberPunk;

namespace Cyber.UnitTest
{
    [TestClass]
    public class TestGaming
    {
        [TestMethod]
        public void TestAction()
        {
            MainWindow main = new MainWindow();
            Assert.IsNotNull(main);
        }

        

        [TestMethod]
        public void TestDice10Launch()
        {

        }
    }
}
