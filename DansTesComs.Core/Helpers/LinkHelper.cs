using System.Linq;
using System.Text.RegularExpressions;

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
        /// <summary>
        /// verifi si le lien est valide pour avoir un champ embed
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static bool IsLinkEmbedEnable(this string link)
        {
            if (AvailableSite.Any(s => link.Contains(s.DommainName)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// recupere le champ embed d'un lien
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
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

        /// <summary>
        /// transforme les liens d'un text en lien clicable
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nouvelleOnglet">si on doit ouvrir dans un nouvel onglet</param>
        /// <returns></returns>
        public static string TextToTextLink(this string text,bool nouvelleOnglet = true)
        {
            return Regex.Replace(text, RegexPattern.UrlRegex, string.Format("<a href=\"$0\" {0} >$0</a>",nouvelleOnglet?" target=\"_blank\"":string.Empty));
        }

        #region delegate embed function

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

        
