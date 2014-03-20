using System;
using System.Linq;
using Empleado;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UnitTests1
    {
        [Test]
        public void Pass()
        {
            var p = new Proxy();
           var rawesults=  p.GetActive();
            var results = rawesults.ToList();
            Assert.True(results.Count >0 );
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }
    }
}