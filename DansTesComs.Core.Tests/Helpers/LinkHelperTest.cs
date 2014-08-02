using System;
using System.Collections.Generic;
using DansTesComs.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DansTesComs.Core.Tests.Helpers
{
    [TestClass]
    public class LinkHelperTest
    {
        [TestMethod]
        public void TestGetDomainRegex()
        {
            var list = new List<Tuple<string, string>>()
            {
                new Tuple<string,string>("https://www.youtube.com/?hl=fr&gl=FR", "www.youtube.com"),
                new Tuple<string,string>("http://www.dailymotion.com/video/x162xu2_live-corobizar_videogames", "www.dailymotion.com"),
                new Tuple<string,string>("https://technet.microsoft.com/library/security/954462", "technet.microsoft.com"),
                new Tuple<string,string>("https://play.spotify.com/radio", "play.spotify.com"),
            };
            foreach (var tuple in list)
            {
                Assert.AreEqual(tuple.Item2, tuple.Item1.GetDomainName());
            }
        }

        [TestMethod]
        public void TestIsLinkEmbedEnable()
        {
            var list = new List<Tuple<string, bool>>()
            {
                new Tuple<string,bool>("https://www.youtube.com/?hl=fr&gl=FR", true),
                new Tuple<string,bool>("http://www.dailymotion.com/video/x162xu2_live-corobizar_videogames", true),
                new Tuple<string,bool>("https://trucnull.com/library/security/954462", false),
                new Tuple<string,bool>("https://zientek.com/radio", false),
                new Tuple<string,bool>("https://www.youtube.fr", false),
            };
            foreach (var tuple in list)
            {
                Assert.AreEqual(tuple.Item2, tuple.Item1.IsLinkEmbedEnable());
            }
        }

        [TestMethod]
        public void TestLinkGetEmbedVideo()
        {
            var list = new List<Tuple<string, string>>()
            {
                new Tuple<string,string>("https://www.youtube.com/watch?v=g0ThdkbNyBs", string.Format("<iframe width=\"{0}\" height=\"{1}\" src=\"//www.youtube.com/embed/g0ThdkbNyBs\" frameborder=\"0\" ></iframe>", LinkHelper.LargeurFrame, LinkHelper.HauteurFrame)),
                new Tuple<string,string>("https://www.youtube.com/watch?v=VJ0I773sFbw", string.Format("<iframe width=\"{0}\" height=\"{1}\" src=\"//www.youtube.com/embed/VJ0I773sFbw\" frameborder=\"0\" ></iframe>", LinkHelper.LargeurFrame, LinkHelper.HauteurFrame)),
                new Tuple<string,string>("https://www.youtube.com/watch?v=VJ0I773sFbw&feature=youtu.be&t=5s", string.Format("<iframe width=\"{0}\" height=\"{1}\" src=\"//www.youtube.com/embed/VJ0I773sFbw\" frameborder=\"0\" ></iframe>", LinkHelper.LargeurFrame, LinkHelper.HauteurFrame)),
                new Tuple<string,string>("http://www.dailymotion.com/video/x162xu2_live-corobizar_videogames", string.Format("<iframe frameborder=\"0\" width=\"{0}\" height=\"{1}\" src=\"//www.dailymotion.com/embed/video/x162xu2\" ></iframe>",  LinkHelper.LargeurFrame, LinkHelper.HauteurFrame)),
                new Tuple<string,string>("https://www.youtube.com/watch&feature=youtu.be&t=5s", "https://www.youtube.com/watch&feature=youtu.be&t=5s"),
                new Tuple<string,string>("http://vimeo.com/91207820", string.Format("<iframe src=\"//player.vimeo.com/video/91207820\" width=\"{0}\" height=\"{1}\" frameborder=\"0\"></iframe>",LinkHelper. LargeurFrame, LinkHelper.HauteurFrame)),
                new Tuple<string,string>("http://vimeo.com/channels/staffpicks/101584491", string.Format("<iframe src=\"//player.vimeo.com/video/101584491\" width=\"{0}\" height=\"{1}\" frameborder=\"0\"></iframe>",LinkHelper. LargeurFrame, LinkHelper.HauteurFrame)),
            };
            foreach (var tuple in list)
            {
                Assert.AreEqual(tuple.Item2, LinkHelper.LinkGetEmbedVideo(tuple.Item1));
            }
        }
    }
}
