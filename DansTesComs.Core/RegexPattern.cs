namespace DansTesComs.Core
{
    public class RegexPattern
    {
        public const string CommentaireExtRegex = "(.+) > (.+)";
        public const string PseudoValidRegex = "^[a-zA-Z0-9]+$";

        public const string DomainNameRegex = @"^https?:\/\/([\da-z\.-]+\.[a-z]{2,6})(\/.+)";
        public const string UrlRegex = @"https?:\/\/([\da-z\.-]+\.[a-z]{2,6})(\/?[^ ]+)";
        public const string YoutubeRegex = @"^https?:\/\/www\.youtube\.com\/watch\?v=([a-zA-Z0-9]+)(&.+)?$";
        public const string DailyMotionRegex = @"^https?:\/\/www\.dailymotion\.com\/video\/([a-zA-Z0-9]+)(_.+)?$";
        public const string VimeoRegex = @"^https?:\/\/vimeo\.com\/(.+\/)?([0-9]+)$";
        public const string ValidYoutubeId = "^([a-zA-Z0-9]+)$";
        public const string ValidVimeoId = "^([0-9]+)$";
    }
}
