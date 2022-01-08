using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestOk()
        {
            Assert.Pass();
        }

        [Test]
        public void TestFail()
        {
            Assert.Pass("It's okay!");
        }
    }
}