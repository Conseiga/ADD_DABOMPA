using ADD_DABOMPA.Models;
using ADD_DABOMPA.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;



namespace ADD_DABOMPA.ViewModels
{
    internal class LoginViewModel : ViewModelsBase
    {
        public LoginViewModel()
        {
            LoginCommand = new ViewModelsCommand(ExecuteLogin, CanExecuteLogin);
            _currentUser = new UserModel(); // Initialize user model
        }



        private UserModel _currentUser = new UserModel(); // Holds input data (email/password)

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

        // Command bound to the login button
        public ICommand LoginCommand { get; }

        private bool CanExecuteLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        // Logic to validate login
        private async void ExecuteLogin()
        {
            try
            {
                var userFromDb = await Task.Run(() => UserRepository.GetUserByEmail(Email)); // Async call

                if (userFromDb == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                // Secure password checking should be used in real applications
                if (userFromDb.password == Password)
                {
                    MessageBox.Show("Login successful!");
                    // Navigate to another page here
                }
                else
                {
                    MessageBox.Show("Wrong password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}
