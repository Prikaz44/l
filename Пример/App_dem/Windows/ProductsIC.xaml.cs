using App_dem.Classes;
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

namespace App_dem.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductsIC.xaml
    /// </summary>
    public partial class ProductsIC : Window
    {
        public ProductsIC()
        {
            InitializeComponent();
            icProducts.ItemsSource = DataBase.Сontext.Товары.ToList();

            txtCurrentUser.Text = User.lastUser.ФИО;
        }

        private void btnExitUser_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
