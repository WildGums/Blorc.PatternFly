namespace Blorc.Dom.Injectors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class InjectorBase : IInjectorValueProvider
    {
        public string GetValue()
        {
            var stringBuilder = new StringBuilder();

            var elementName = ElementName;
            stringBuilder.Append($"<{elementName}");

            var attributes = GetAttributes();

            foreach (var attribute in attributes)
            {
                if (attribute.Value != null)
                {
                    stringBuilder.Append($" {attribute.Key}=\"{attribute.Value}\"");
                }
            }

            stringBuilder.Append(" />");

            return stringBuilder.ToString();
        }

        protected abstract string ElementName { get; }

        protected abstract Dictionary<string, string> GetAttributes();
    }
}
