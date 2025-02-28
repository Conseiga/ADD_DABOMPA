using ADD_DABOMPA.Views.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADD_DABOMPA;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Home : Window
{
    private UserC_SideBarMenu uc_UserC_SideBarMenu;
    public Home()
    {
        InitializeComponent();
        uc_UserC_SideBarMenu = new UserC_SideBarMenu(frm_body);
        Grid.SetRow(uc_UserC_SideBarMenu, 0); // Row 1  
        Grid.SetColumn(uc_UserC_SideBarMenu, 0); // Column 1  
        grd_MainGrid.Children.Add(uc_UserC_SideBarMenu);
    }
}