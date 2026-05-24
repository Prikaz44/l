using App_dem.Model;
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
using App_dem.Classes;

namespace App_dem.Windows
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
            txtCurrentUser.Text = User.lastUser.ФИО;
            dgProducts.ItemsSource = DataBase.Сontext.Товары.ToList();
        }

        private void btnExitUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
