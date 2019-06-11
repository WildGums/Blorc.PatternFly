namespace Blorc.Dom.Injectors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Meta : InjectorBase
    {
        public string Charset { get; set; }

        public string Content { get; set; }

        public string HttpEquiv { get; set; }

        public string Name { get; set; }

        protected override string ElementName => "meta";

        protected override Dictionary<string, string> GetAttributes()
        {
            var attributes = new Dictionary<string, string>();

            attributes["charset"] = Charset;
            attributes["content"] = Content;
            attributes["http-equiv"] = HttpEquiv;
            attributes["name"] = Name;

            return attributes;
        }
    }
}
