using App_dem.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_dem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            //auth(txtLogin.Text, txtPass.Password);
            //
            //auth("yzls62@outlook.com", "JlFRCZ"); //админ
            //auth("1diph5e@tutanota.com", "8ntwUp"); //Менеджер
            auth("5d4zbu@tutanota.com", "rwVDh9"); //Авторизированный клиент
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            auth("Гость", "Гость");
        }

        private void auth(string login, string pass)
        {
            Пользователи currentUser = User.getUser(login, pass);
            if (currentUser == null)
            {
                MessageBox.Show("Данные не найдены", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                //TODO: включить на релизе
                MessageBox.Show("Добро пожаловать, " + currentUser.ФИО + "!", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);

                //переход на окно в зависимости от роли
                Window window;

                switch (currentUser.Роль_сотрудника)
                {
                    case "Администратор":
                        window = new Windows.MenuEmp();
                        break;
                    case "Менеджер":
                        window = new Windows.MenuEmp();
                        break;
                    case "Авторизированный клиент":
                        window = new Windows.ProductsIC();
                        break;
                    default:
                        window = new Windows.ProductsManager(); //это гость
                        //window = new Windows.ProductsIC(); //это гость
                        break;
                }
                window.ShowDialog();
            }
        }
    }
}
