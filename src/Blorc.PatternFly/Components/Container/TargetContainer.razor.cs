namespace Blorc.PatternFly.Components.Container
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public class TargetContainerComponent : BlorcComponentBase
    {
        public TargetContainerComponent()
        {
            RenderFragments.CollectionChanged += RenderFragments_OnCollectionChanged;
        }

        /// <summary>
        ///     Gets or sets the render fragments.
        /// </summary>
        public ObservableCollection<RenderFragment> RenderFragments { get; } = new ObservableCollection<RenderFragment>();

        /// <summary>
        /// The render fragments_ on collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RenderFragments_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}
