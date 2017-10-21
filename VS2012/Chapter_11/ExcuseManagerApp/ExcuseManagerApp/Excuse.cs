using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManagerApp
{
    using System.ComponentModel;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://www.headfirstlabs.com/ExcuseManager")]
    class Excuse : INotifyPropertyChanged
    {
        public string DateWarning { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Results { get; set; }

        [DataMember]
        private DateTime lastUsed = DateTime.MinValue;
        public string LastUsed
        {
            get
            {
                if (lastUsed != DateTime.MinValue)
                    return lastUsed.ToString();
                else
                    return String.Empty;
            }
            set
            {
                DateTime d = DateTime.MinValue;
                bool dateIsValid = DateTime.TryParse(value, out d);
                lastUsed = d;

                if (!String.IsNullOrEmpty(value) && !dateIsValid)
                {
                    DateWarning = "Invalid date: " + value;
                }
                else
                    DateWarning = String.Empty;
                OnPropertyChanged("DateWarning");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
