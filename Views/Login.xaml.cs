using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ADD_DABOMPA.Views
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    /// 

    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty IsPasswordEmptyProperty =
            DependencyProperty.RegisterAttached("IsPasswordEmpty",
                typeof(bool),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static bool GetIsPasswordEmpty(DependencyObject obj) => (bool)obj.GetValue(IsPasswordEmptyProperty);
        public static void SetIsPasswordEmpty(DependencyObject obj, bool value) => obj.SetValue(IsPasswordEmptyProperty, value);

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
                typeof(bool),
                typeof(PasswordBoxHelper),
                new PropertyMetadata(false, Attach));

        private static void Attach(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox pb)
            {
                pb.PasswordChanged += (s, _) =>
                    SetIsPasswordEmpty(pb, string.IsNullOrEmpty(pb.Password));
            }
        }
    }

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void WindowsMouseButtonLeftDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenApplication(object sender, RoutedEventArgs e)
        {
            Home mainWindow = new Home();
            mainWindow.Show();
            MessageBox.Show("Vous êtes connecté avec succès !", "Connection Réussie", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
