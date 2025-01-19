﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AWSEC2-CloudPC.Common.Cryptography;
using AWSEC2-CloudPC.Common.Helpers;

namespace AWSEC2-CloudPC.Common.Tests.Cryptography
{
    [TestClass]
    public class Sha256Tests
    {
        [TestMethod, TestCategory("Cryptography")]
        public void ComputeHashTest()
        {
            var input = StringHelper.GetRandomString(100);
            var result = Sha256.ComputeHash(input);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, input);
        }
    }
}
