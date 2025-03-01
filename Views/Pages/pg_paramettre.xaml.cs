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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADD_DABOMPA.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour pg_paramettre.xaml
    /// </summary>
    public partial class pg_paramettre : Page
    {
        private bool isDarkTheme = false;

        public pg_paramettre()
        {
            InitializeComponent();
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            string newThemePath = isDarkTheme ? "RD_DarkMode.xaml" : "RD_LightMode.xaml";
            var newTheme = (ResourceDictionary)Application.LoadComponent(new Uri($"/Views/Resources/Styles/{newThemePath}", UriKind.Relative));
            Application.Current.Resources.MergedDictionaries[0] = newTheme;
        }
    }
}
