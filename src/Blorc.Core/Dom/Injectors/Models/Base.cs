namespace Blorc.Dom.Injectors
{
    using System.Collections.Generic;

    public class Base : InjectorBase
    {
        public string Href { get; set; }

        public string Target { get; set; }

        protected override string ElementName => "base";

        protected override Dictionary<string, string> GetAttributes()
        {
            var attributes = new Dictionary<string, string>();

            attributes["href"] = Href;
            attributes["target"] = Target;

            return attributes;
        }
    }
}
