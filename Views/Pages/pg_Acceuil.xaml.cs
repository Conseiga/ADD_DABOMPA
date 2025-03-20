using ADD_DABOMPA.Views.UserControls;
using System.Windows.Controls;


namespace ADD_DABOMPA.Views
{
    /// <summary>
    /// Logique d'interaction pour pg_Acceuil.xaml
    /// </summary>
    public partial class pg_Acceuil : Page
    {
        private UserC_Apropos _Apropos;

        public pg_Acceuil()
        {
            InitializeComponent();
            _Apropos = new UserC_Apropos();
            Grid.SetRow(_Apropos, 0);
            Grid.SetColumn(_Apropos, 0);
            grd_Content.Children.Add(_Apropos);
        }


    }
}
