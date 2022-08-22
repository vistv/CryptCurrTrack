using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CryptCurrTrack.Model
{
    class BaseModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
