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

        [Test]
        [Ignore("worthless")]
        public void Test()
        {
            Assert.AreEqual(true, false);
        }

        [Test]
        public void KJKJKJK()
        {
            var x = 5 * 2;
            Assert.AreEqual(5 + 5, x);
        }
    }
}