using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ADD_DABOMPA.ViewModels
{
    public abstract class ViewModelsBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
