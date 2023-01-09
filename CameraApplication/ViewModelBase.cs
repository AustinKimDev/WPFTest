using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace CameraApplication
{
    [Serializable]
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore]
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
                properties.Add(propertyName, default(T));

            var oldValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(oldValue, value))
            {
                properties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
                return default(T);
            else
                return (T)properties[propertyName];
        }

        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}