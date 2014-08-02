using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DansTesComs.Core.Helpers
{
    public static class LinkHelper
    {
        public const int LargeurFrame = 500;
        public const int HauteurFrame = 300;

        private static readonly EmbedWebSite[] AvailableSite = { 
                                                                   new EmbedWebSite { DommainName = "www.youtube.com", GetEmbed = YoutubeFunction },
                                                                   new EmbedWebSite { DommainName = "www.dailymotion.com", GetEmbed = DailyMotionFunction },
                                                                   new EmbedWebSite { DommainName = "vimeo.com", GetEmbed = VimeoFunction },
                                                               };

        public static bool IsLinkEmbedEnable(this string link)
        {
            if (AvailableSite.Any(s => link.Contains(s.DommainName)))
            {
                return true;
            }
            return false;
        }

        public static string LinkGetEmbedVideo(string link)
        {
            if (link.IsLinkEmbedEnable())
            {
                foreach (var embedWebSite in AvailableSite)
                {
                    if (embedWebSite.DommainName == link.GetDomainName())
                    {
                        return embedWebSite.GetEmbed(link);
                    }
                }
            }
            return link;
        }

        internal static string GetDomainName(this string link)
        {
            return Regex.Replace(link, RegexPattern.DomainNameRegex, "$1");
        }

        #region delegate function

        private static string YoutubeFunction(string link)
        {
            string videoId = Regex.Replace(link, RegexPattern.YoutubeRegex, "$1");
            if (Regex.IsMatch(videoId,RegexPattern.ValidYoutubeId))
            {
                return string.Format("<iframe width=\"{1}\" height=\"{2}\" src=\"//www.youtube.com/embed/{0}\" frameborder=\"0\" ></iframe>", videoId, LargeurFrame, HauteurFrame);                
            }
            return link;
        }

        private static string DailyMotionFunction(string link)
        {
            string videoId = Regex.Replace(link, RegexPattern.DailyMotionRegex, "$1");
            if (Regex.IsMatch(videoId,RegexPattern.ValidYoutubeId))
            {
                return string.Format("<iframe frameborder=\"0\" width=\"{1}\" height=\"{2}\" src=\"//www.dailymotion.com/embed/video/{0}\" ></iframe>", videoId, LargeurFrame, HauteurFrame);                
            }
            return link;
        }
        private static string VimeoFunction(string link)
        {
            string videoId = Regex.Replace(link, RegexPattern.VimeoRegex, "$2");
            if (Regex.IsMatch(videoId,RegexPattern.ValidVimeoId))
            {
                return string.Format("<iframe src=\"//player.vimeo.com/video/{0}\" width=\"{1}\" height=\"{2}\" frameborder=\"0\"></iframe>", videoId, LargeurFrame, HauteurFrame);                
            }
            return link;
        }
        #endregion
    }
}            

        
