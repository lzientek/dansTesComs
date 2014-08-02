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

        private static readonly EmbedWebSite[] AvailableSite = { new EmbedWebSite { DommainName = "www.youtube.com", GetEmbed = YoutubeFunction }, };

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
        #endregion
    }
}
