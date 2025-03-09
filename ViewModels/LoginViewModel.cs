using ADD_DABOMPA.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ADD_DABOMPA.ViewModels
{
    internal class LoginViewModel : ViewModelsBase
    {
        public LoginViewModel() { }

        public ObservableCollection<UserModel> Users { get; set; }

        private UserModel user;


        public UserModel User
        {
            get { return user; }
            set { 
                user = value;
                OnpropertyChanged();
            }
        }

    }
}
