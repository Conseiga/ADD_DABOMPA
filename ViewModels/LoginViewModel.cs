using ADD_DABOMPA.Models;
using ADD_DABOMPA.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;



namespace ADD_DABOMPA.ViewModels
{
    internal class LoginViewModel : ViewModelsBase
    {
        // Command bound to the login button
        public ICommand LoginCommand { get; }

        private UserModel _currentUser; // Holds input data (email/password)


        public LoginViewModel()
        {
            LoginCommand = new ViewModelsCommand(ExecuteLogin, CanExecuteLogin);
            _currentUser = new UserModel(); // Initialize user model
        }


        // Properties bound to the View's email/password fields
        public string Email
        {
            get => _currentUser.email;
            set
            {
                if (_currentUser.email != value)
                {
                    _currentUser.email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _currentUser.password;
            set
            {
                if (_currentUser.password != value)
                {
                    _currentUser.password = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool CanExecuteLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        // Logic to validate login
        public event Action RequestClose; // Add this line

        private async void ExecuteLogin()
        {
            try
            {
                var userFromDb = await Task.Run(() => UserRepository.GetUserByEmail(Email));

                if (userFromDb == null)
                {
                    MessageBox.Show("User not found.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (userFromDb.password == Password)
                {
                    RequestClose?.Invoke(); // Trigger the event to close the window
                }
                else
                {
                    MessageBox.Show("Wrong password.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
