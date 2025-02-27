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
using ADD_DABOMPA;
using ADD_DABOMPA.Views.Pages;

namespace ADD_DABOMPA.Views.UserControls
{
    

    /// <summary>
    /// Logique d'interaction pour UserC_SideBarMenu.xaml
    /// </summary>
    public partial class UserC_SideBarMenu : UserControl
    {
        Home parentWindow;
        pg_Acceuil pageAcceuil;
        pg_Departement pageDepartement;
        pg_Membre pageMembre;
        pg_Flux_Monetaire pageFlux_Monetaire;
        pg_paramettre pageParaettre;

        public UserC_SideBarMenu()
        {
            InitializeComponent();
            this.Width = 50; // Initial collapsed state

            // Initialize windows and pages 
            parentWindow = VisualTreeHelper.GetParent(this);
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
            if (parentWindow is Home homeWindow)
            {
                switch (sender)
                {
                    case btn_Aceuil:
                        homeWindow.frm_body.Content = pageAcceuil;
                        break;
                    case btn_membre:
                        homeWindow.frm_body.Content = pageMembre;
                        break;
                    case btn_departement:
                        homeWindow.frm_body.Content = pageDepartement;
                        break;
                    case btn_flux_monetaire:
                        homeWindow.frm_body.Content = pageFlux_Monetaire;
                        break;
                    default:
                        homeWindow.frm_body.Content = pageParaettre;
                }
            }
            
        }
    }
}
