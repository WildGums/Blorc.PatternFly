// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitchActionDefinition.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Blorc.PatternFly.Annotations;

    public class SwitchActionDefinition : ActionDefinition, INotifyPropertyChanged
    {
        private bool _isChecked;

        private bool _isDisabled;

        private string _label;

        public event PropertyChangedEventHandler PropertyChanged;

        public Action<object, bool> Action { get; set; }

    

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (value == _isChecked)
                {
                    return;
                }

                _isChecked = value;
                OnPropertyChanged();
            }
        }

        public bool IsDisabled
        {
            get => _isDisabled;
            set
            {
                if (value == _isDisabled)
                {
                    return;
                }

                _isDisabled = value;
                OnPropertyChanged();
            }
        }

        public string Key { get; set; }

        public string Label
        {
            get => _label;
            set
            {
                if (value == _label)
                {
                    return;
                }

                _label = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == nameof(IsChecked))
            {
                Action(DataContext, IsChecked);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
