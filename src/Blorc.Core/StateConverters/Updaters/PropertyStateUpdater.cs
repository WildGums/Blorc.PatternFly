namespace Blorc.StateConverters
{
    using Blorc.Reflection;

    public class PropertyStateUpdater : StateUpdaterBase
    {
        public PropertyStateUpdater(object instance, string propertyName) 
            : base(x =>
            {
                //Log.Debug($"Updating '{instance.GetType().Name}.{propertyName}' to '{x}'");

                PropertyHelper.SetPropertyValue(instance, propertyName, x);

                //Log.Debug($"'{instance.GetType().Name}.{propertyName}' is now '{PropertyHelper.GetPropertyValue(instance, propertyName)}'");
            })
        {
        }
    }
}
