namespace Blorc.Dom.Injectors
{
    public class Css : Link
    {
        public Css(string href)
        {
            Href = href;
            Rel = "stylesheet";
            Type = "text/css";
        }
    }
}
