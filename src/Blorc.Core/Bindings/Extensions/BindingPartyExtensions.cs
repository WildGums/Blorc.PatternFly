namespace Blorc.Bindings
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Extension methods for binding parties.
    /// </summary>
    public static class BindingPartyExtensions
    {
        private static readonly MethodInfo AddEventMethodInfo;

        static BindingPartyExtensions()
        {
            AddEventMethodInfo = typeof(BindingParty).GetMethod("AddEvent");
            if (AddEventMethodInfo is null)
            {
                throw new NotSupportedException($"Cannot find BindingParty.AddEvent method, BindingPartyExtensions will not be supported");
            }
        }

        /// <summary>
        /// Adds the event by automatically retrieving the event args type.
        /// </summary>
        /// <param name="bindingParty">The binding party.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="bindingParty"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="bindingParty"/> is <c>null</c>.</exception>
        public static void AddEvent(this BindingParty bindingParty, string eventName)
        {
            var instance = bindingParty.Instance;
            if (instance is null)
            {
                throw new InvalidOperationException($"The BindingParty '{bindingParty}' is no longer alive, cannot add event '{eventName}'");
            }

            var instanceType = instance.GetType();
            var eventInfo = instanceType.GetEvent(eventName);
            if (eventInfo is null)
            {
                throw new InvalidOperationException($"Event '{instanceType.Name}.{eventName}' does not exist");
            }

            var eventHandlerType = eventInfo.EventHandlerType;
            var eventArgsType = eventHandlerType.GetGenericArguments()[0];

            var genericAddEventMethod = AddEventMethodInfo.MakeGenericMethod(eventArgsType);
            genericAddEventMethod.Invoke(bindingParty, new object[] { eventName });
        }
    }
}
