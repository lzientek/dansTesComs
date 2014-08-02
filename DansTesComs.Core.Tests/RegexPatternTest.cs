using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.Core.Tests
{
    [TestClass]
    public class RegexPatternTest
    {
        [TestMethod]
        public void TestPseudoRegex()
        {
            var list = new List<Tuple<string, bool>>()
            {
                new Tuple<string, bool>("AZERTY", true),
                new Tuple<string, bool>("aZeRtY", true),
                new Tuple<string, bool>("aZezrZR156516", true),
                new Tuple<string, bool>("15efefzzeZETze", true),
                new Tuple<string, bool>("zfaibvza165z1", true),
                new Tuple<string, bool>("AZE1RTY", true),
                new Tuple<string, bool>("AZE 1RTY", false),
                new Tuple<string, bool>("AZE1-RTY", false),
                new Tuple<string, bool>("AZE1RT_Y", false),
                new Tuple<string, bool>("AZE1&RTY", false),
                new Tuple<string, bool>("AZE1/RTY", false),
                new Tuple<string, bool>("AZE1[RTY", false),
            };
            foreach (var tuple in list)
            {
                Assert.AreEqual(tuple.Item2, Regex.IsMatch(tuple.Item1, RegexPattern.PseudoValidRegex));
            }
        }

        [TestMethod]
        public void TestYoutubeRegex()
        {
            var list = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("https://www.youtube.com/watch?v=yLLlW1vWqZ8", "yLLlW1vWqZ8"),
                new Tuple<string, string>("https://www.youtube.com/watch?v=keiPSPR8MFY", "keiPSPR8MFY"),
                new Tuple<string, string>("http://youtu.be/keiPSPR8MFY?t=32s", "http://youtu.be/keiPSPR8MFY?t=32s"),
                new Tuple<string, string>("https://www.youtube.com/watch?v=keiPSPR8MFY&feature=youtu.be&t=49s", "keiPSPR8MFY"),

            };
            foreach (var tuple in list)
            {
                Assert.AreEqual(tuple.Item2, Regex.Replace(tuple.Item1, RegexPattern.YoutubeRegex,"$1"));
            }
        }
    }
}
