namespace Blorc.Dom.Injectors
{
    using System.Collections.Generic;

    public class Link : InjectorBase
    {
        public string Charset { get; set; }

        public string CrossOrigin { get; set; }

        public string Href { get; set; }

        public string HrefLang { get; set; }

        public string Media { get; set; }

        public string Rel { get; set; }

        public string Sizes { get; set; }

        public string Type { get; set; }

        protected override string ElementName => "link";

        protected override Dictionary<string, string> GetAttributes()
        {
            var attributes = new Dictionary<string, string>();

            attributes["charset"] = Charset;
            attributes["crossorigin"] = CrossOrigin;
            attributes["href"] = Href;
            attributes["hreflang"] = HrefLang;
            attributes["media"] = Media;
            attributes["rel"] = Rel;
            attributes["sizes"] = Sizes;
            attributes["type"] = Type;

            return attributes;
        }
    }
}
