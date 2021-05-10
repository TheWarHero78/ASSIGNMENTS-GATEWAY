using NUnit.Framework;
using System;

namespace Assignment9.Test
{
    public class Tests
    {
        [Test]
        public void TestAddCustom3()
        {
            var sut = new Math();
            var res = sut.Add(42, 42);
            Assert.That(res, Is.Not.Approx(80d));
        }
    }
}