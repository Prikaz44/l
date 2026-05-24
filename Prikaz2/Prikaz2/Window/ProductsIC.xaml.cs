using Prikaz2.Classes;
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
using Prikaz2.Model;




namespace Prikaz2.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductIC.xaml
    /// </summary>
    public partial class ProductIC : Window
    {
        public ProductIC()
        {
            InitializeComponent();
            txtCurrentUser.Text = User.lastUser.ФИО;
            LoadProducts();
        }

        private void btnExitUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadProducts()
        {
            lvProducts.ItemsSource = DataBase.context.Товары.ToList();
        }
    }
}
