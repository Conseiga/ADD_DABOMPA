﻿using System;
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

namespace ADD_DABOMPA.Views.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserC_HeadBar.xaml
    /// </summary>
    public partial class UserC_HeadBar : UserControl
    {
        public Home parentWindow {get; private set; }

        public UserC_HeadBar(Home parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Etes vous sure de vouloir vous déconnecter ?", "Déconnection", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Login loginWindow = new Login();
                loginWindow.Show();
                parentWindow.Close();
            }
        }
    }
}
