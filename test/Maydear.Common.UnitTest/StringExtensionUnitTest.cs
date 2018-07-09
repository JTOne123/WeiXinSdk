using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Maydear.Common.Extensions;

namespace Maydear.Common.UnitTest
{
    [TestClass]
    public class StringExtensionUnitTest
    {
        [TestMethod]
        public void ExtractHostTestMethod()
        {
            string url = "http://api.dev.seeshion.com/aa";

            var host = url.ExtractHost();
            Console.WriteLine(host);
            Assert.AreEqual("api.dev.seeshion.com", host);
        }

        [TestMethod]
        public void ExtractHostTestMethodwww()
        {
            string url = "http://www.seeshion.com/aa";

            var host = url.ExtractHost();
            Console.WriteLine(host);
            Assert.AreEqual("www.seeshion.com", host);
        }
        [TestMethod]
        public void ExtractHostTestMethodProt()
        {
            string url = "http://www.seeshion.com:123/aa";

            var host = url.ExtractHost();
            Console.WriteLine(host);
            Assert.AreEqual("www.seeshion.com", host);
        }

        [TestMethod]
        public void ExtractHostTestMethodIpProt()
        {
            string url = "http://192.168.1.1:123/aa";

            var host = url.ExtractHost();
            Console.WriteLine(host);
            Assert.AreEqual("192.168.1.1", host);
        }
        [TestMethod]
        public void ExtractHostTestMethodSsh()
        {
            string url = "ssh://192.168.1.1/";

            var host = url.ExtractHost();
            Console.WriteLine(host);
            Assert.AreEqual("192.168.1.1", host);
        }

        [TestMethod]
        public void ExtractHostTestMethodString()
        {
            string url = "sssssssssss";

            var host = url.ExtractHost();
            Console.WriteLine(host);
            Assert.AreNotEqual("sssssssssss", host);
        }


        [TestMethod]
        public void RelativelyPathTestMethodString()
        {
            string url = "http://api.dev.seeshion.com/aa/sss/sss?aa";

            var host = url.ExtractRelativelyPath();
            Console.WriteLine(host);
            Assert.AreNotEqual("aa", host);
        }
    }
}
