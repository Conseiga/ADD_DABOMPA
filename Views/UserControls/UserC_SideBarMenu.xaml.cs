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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADD_DABOMPA.Views.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserC_SideBarMenu.xaml
    /// </summary>
    public partial class UserC_SideBarMenu : UserControl
    {
        public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register("IsExpanded", typeof(bool), typeof(UserC_SideBarMenu),
            new PropertyMetadata(false));

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public UserC_SideBarMenu()
        {
            InitializeComponent();
            this.Width = 50; // Initial collapsed state
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
            var animation = IsExpanded ?
                FindResource("ExpandAnimation") as Storyboard :
                FindResource("CollapseAnimation") as Storyboard;
            animation?.Begin(this);
        }
    }
}
