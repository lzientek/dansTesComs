using System;

namespace DansTesComs.Core.Helpers
{
    struct EmbedWebSite
    {
        public string DommainName { get; set; } 

        public Func<string,string> GetEmbed { get; set; }
    }
}