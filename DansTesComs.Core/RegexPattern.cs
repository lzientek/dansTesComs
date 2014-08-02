using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DansTesComs.Core
{
    public class RegexPattern
    {
        public const string CommentaireExtRegex = "(.+) > (.+)";
        public const string PseudoValidRegex = "^[a-zA-Z0-9]+$";

        public const string DomainNameRegex = @"^https?:\/\/([\da-z\.-]+\.[a-z]{2,6})(\/.+)";
        public const string YoutubeRegex = @"^https?:\/\/www\.youtube\.com/watch\?v=([a-zA-Z0-9]+)(&.+)?$";
        public const string ValidYoutubeId = "^([a-zA-Z0-9]+)$";
    }
}
