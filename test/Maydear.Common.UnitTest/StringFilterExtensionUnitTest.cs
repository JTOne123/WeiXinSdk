using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maydear.Common.Filters;
namespace Maydear.Common.UnitTest
{
    [TestClass]
    public class StringFilterExtensionUnitTest
    {
        [TestMethod]
        public void IsChinaMobilePhone130_9()
        {
            Assert.IsTrue("13028758701".IsChinaMobilePhone());
            Assert.IsTrue("13128758701".IsChinaMobilePhone());
            Assert.IsTrue("13228758701".IsChinaMobilePhone());
            Assert.IsTrue("13328758701".IsChinaMobilePhone());
            Assert.IsTrue("13428758701".IsChinaMobilePhone());
            Assert.IsTrue("13528758701".IsChinaMobilePhone());
            Assert.IsTrue("13628758701".IsChinaMobilePhone());
            Assert.IsTrue("13728758701".IsChinaMobilePhone());
            Assert.IsTrue("13828758701".IsChinaMobilePhone());
            Assert.IsTrue("13928758701".IsChinaMobilePhone());
        }
        [TestMethod]
        public void IsChinaMobilePhone140_8()
        {
            Assert.IsTrue("14028758701".IsChinaMobilePhone());
            Assert.IsTrue("14128758701".IsChinaMobilePhone());
            Assert.IsTrue("14228758701".IsChinaMobilePhone());
            Assert.IsTrue("14328758701".IsChinaMobilePhone());
            Assert.IsTrue("14428758701".IsChinaMobilePhone());
            Assert.IsTrue("14528758701".IsChinaMobilePhone());
            Assert.IsTrue("14628758701".IsChinaMobilePhone());
            Assert.IsTrue("14728758701".IsChinaMobilePhone());
            Assert.IsTrue("14828758701".IsChinaMobilePhone());
        }
        [TestMethod]
        public void IsChinaMobilePhone150_3_5_9()
        {
            Assert.IsTrue("15028758701".IsChinaMobilePhone());
            Assert.IsTrue("15128758701".IsChinaMobilePhone());
            Assert.IsTrue("15228758701".IsChinaMobilePhone());
            Assert.IsTrue("15328758701".IsChinaMobilePhone());
            Assert.IsFalse("15428758701".IsChinaMobilePhone());
            Assert.IsTrue("15528758701".IsChinaMobilePhone());
            Assert.IsTrue("15628758701".IsChinaMobilePhone());
            Assert.IsTrue("15728758701".IsChinaMobilePhone());
            Assert.IsTrue("15828758701".IsChinaMobilePhone());
            Assert.IsTrue("15928758701".IsChinaMobilePhone());
        }

        [TestMethod]
        public void IsChinaMobilePhone166()
        {
            Assert.IsFalse("16028758701".IsChinaMobilePhone());
            Assert.IsFalse("16128758701".IsChinaMobilePhone());
            Assert.IsFalse("16228758701".IsChinaMobilePhone());
            Assert.IsFalse("16328758701".IsChinaMobilePhone());
            Assert.IsFalse("16428758701".IsChinaMobilePhone());
            Assert.IsFalse("16528758701".IsChinaMobilePhone());
            Assert.IsTrue("16628758701".IsChinaMobilePhone());
            Assert.IsFalse("16728758701".IsChinaMobilePhone());
            Assert.IsFalse("16828758701".IsChinaMobilePhone());
            Assert.IsFalse("16928758701".IsChinaMobilePhone());
        }
        [TestMethod]
        public void IsChinaMobilePhone170_9()
        {
            Assert.IsTrue("17028758701".IsChinaMobilePhone());
            Assert.IsTrue("17128758701".IsChinaMobilePhone());
            Assert.IsTrue("17228758701".IsChinaMobilePhone());
            Assert.IsTrue("17328758701".IsChinaMobilePhone());
            Assert.IsTrue("17428758701".IsChinaMobilePhone());
            Assert.IsTrue("17528758701".IsChinaMobilePhone());
            Assert.IsTrue("17628758701".IsChinaMobilePhone());
            Assert.IsTrue("17728758701".IsChinaMobilePhone());
            Assert.IsTrue("17828758701".IsChinaMobilePhone());
            Assert.IsTrue("17928758701".IsChinaMobilePhone());
        }
        [TestMethod]
        public void IsChinaMobilePhone180_9()
        {
            Assert.IsTrue("18028758701".IsChinaMobilePhone());
            Assert.IsTrue("18128758701".IsChinaMobilePhone());
            Assert.IsTrue("18228758701".IsChinaMobilePhone());
            Assert.IsTrue("18328758701".IsChinaMobilePhone());
            Assert.IsTrue("18428758701".IsChinaMobilePhone());
            Assert.IsTrue("18528758701".IsChinaMobilePhone());
            Assert.IsTrue("18628758701".IsChinaMobilePhone());
            Assert.IsTrue("18728758701".IsChinaMobilePhone());
            Assert.IsTrue("18828758701".IsChinaMobilePhone());
            Assert.IsTrue("18928758701".IsChinaMobilePhone());
        }

        [TestMethod]
        public void IsChinaMobilePhone198_9()
        {
            Assert.IsFalse("19028758701".IsChinaMobilePhone());
            Assert.IsFalse("19128758701".IsChinaMobilePhone());
            Assert.IsFalse("19228758701".IsChinaMobilePhone());
            Assert.IsFalse("19328758701".IsChinaMobilePhone());
            Assert.IsFalse("19428758701".IsChinaMobilePhone());
            Assert.IsFalse("19528758701".IsChinaMobilePhone());
            Assert.IsFalse("19628758701".IsChinaMobilePhone());
            Assert.IsFalse("19728758701".IsChinaMobilePhone());
            Assert.IsTrue("19828758701".IsChinaMobilePhone());
            Assert.IsTrue("19928758701".IsChinaMobilePhone());
        }
    }
}
