using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

// INotifyPropertyChanged notifies the View of property changes, so that Bindings are updated.
namespace CryptCurrTrack.Model
{

    sealed class MainWindow_Model : BaseModel 
    {
        private string rank;
        private string id;
        private string name;

        public string Rank
        {
            get { return rank; }
            set
            {
                if (rank != value)
                {
                    rank = value;
                    OnPropertyChange("Rank");
                }
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChange("Id");
                }
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChange("Name");
                }
            }
        }

        //public string LastName
        //{
        //    get { return user.LastName; }
        //    set
        //    {
        //        if (user.LastName != value)
        //        {
        //            user.LastName = value;
        //            OnPropertyChange("LastName");
        //            // If the first name has changed, the FullName property needs to be udpated as well.
        //            OnPropertyChange("FullName");
        //        }
        //    }
        //}

        //// This property is an example of how model properties can be presented differently to the View.
        //// In this case, we transform the birth date to the user's age, which is read only.
        //public int Age
        //{
        //    get
        //    {
        //        DateTime today = DateTime.Today;
        //        int age = today.Year - user.BirthDate.Year;
        //        if (user.BirthDate > today.AddYears(-age)) age--;
        //        return age;
        //    }
        //}




    }
}