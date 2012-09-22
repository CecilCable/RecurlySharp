using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RecurlySharp.Tests{
    [TestFixture]
    public class SignatureTests{
        [Test]
        public void SignatureGeneratesOkay(){
            var sign = new Signature("Foo").Sign("put-guid-here", new DateTime(2012, 9, 21, 23, 9, 34), new KeyValuePair<string, string>[0]);
            Assert.That(sign, Is.EqualTo("666673fe6c5c45d95c8e65bc03a78ee01c505552|nonce=put-guid-here&timestamp=1348283374"));
        }
    }
}