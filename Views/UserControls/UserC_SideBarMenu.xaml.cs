using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using ADD_DABOMPA;
using ADD_DABOMPA.Views.Pages;

namespace ADD_DABOMPA.Views.UserControls
{
    

    /// <summary>
    /// Logique d'interaction pour UserC_SideBarMenu.xaml
    /// </summary>
    public partial class UserC_SideBarMenu : UserControl
    {
        private Frame _frame;
        private pg_Acceuil pageAcceuil;
        private pg_Departement pageDepartement;
        private pg_Membre pageMembre;
        private pg_Flux_Monetaire pageFlux_Monetaire;
        private pg_paramettre pageParaettre;

        public UserC_SideBarMenu(Frame _frame)
        {
            InitializeComponent();
            this.Width = 50; // Initial collapsed state

            this._frame = _frame;
            pageAcceuil = new pg_Acceuil(); 
            pageDepartement = new pg_Departement(); 
            pageMembre = new pg_Membre();   
            pageFlux_Monetaire = new pg_Flux_Monetaire();
            pageParaettre = new pg_paramettre();
        }

        public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register("IsExpanded", typeof(bool), typeof(UserC_SideBarMenu),
            new PropertyMetadata(false));

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }


        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
            var animation = IsExpanded ?
                FindResource("ExpandAnimation") as Storyboard :
                FindResource("CollapseAnimation") as Storyboard;
            animation?.Begin(this);
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Equals(btn_Aceuil)) _frame.Content = pageAcceuil;
            else if (btn.Equals(btn_membre)) _frame.Content = pageMembre;
            else if (btn.Equals(btn_departement)) _frame.Content = pageDepartement;
            else if (btn.Equals(btn_flux_monetaire)) _frame.Content = pageFlux_Monetaire;
            else _frame.Content = pageParaettre;
        }
    }
}
