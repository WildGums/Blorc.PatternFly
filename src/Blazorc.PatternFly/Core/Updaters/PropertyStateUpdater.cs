namespace Blazorc.PatternFly
{
    public class PropertyStateUpdater : StateUpdaterBase
    {
        public PropertyStateUpdater(object instance, string propertyName) 
            : base(x =>
            {
                Log.Debug($"Updating '{propertyName}' to '{x}'");

                PropertyHelper.SetPropertyValue(instance, propertyName, x);
            })
        {
        }
    }
}
