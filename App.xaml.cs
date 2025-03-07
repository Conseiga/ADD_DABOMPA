using ADD_DABOMPA.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ADD_DABOMPA;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public void AppStartup(object sender, StartupEventArgs e)
    {
        Login login = new Login();
        login.Show();
    }
}

