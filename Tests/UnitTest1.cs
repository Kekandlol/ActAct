using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StrangerThings;
using System.Linq;

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

        [Test]
        public void EnviromentTest()
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddEnvironmentVariables();
            var cfg = configurationBuilder.Build();

            StringAssert.AreEqualIgnoringCase("correct", cfg["CONS"]);
        }

        public void DbConnectionTest()
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddEnvironmentVariables();
            var cfg = configurationBuilder.Build();


            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            // builder.UseNpgsql("Host=localhost;Port=5432;Database=Pook;Username=oak;Password=oakpassword");
            builder.UseNpgsql(cfg["Cons"]);
            using Contex contex = new Contex(builder.Options);
            Assert.DoesNotThrow(() => contex.Database.EnsureDeleted());
            Assert.DoesNotThrow(contex.Database.Migrate);

            contex.Oogas.Add(new Ooga { Booga = "ddfsd" });
            contex.SaveChanges();
            var cnt = contex.Oogas.Count();
            Assert.AreEqual(1, cnt);

        }
    }
}