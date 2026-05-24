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
using Prikaz2.Model;
using Prikaz2.Classes;
using Prikaz2.Windows;

namespace Prikaz2
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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            auth("3", "3");
            //auth("2", "2");
            //auth("1", "1");
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            auth("Гость", "Гость");
        }

        private void auth(string login, string password)
        {
            Пользователи currentUser = User.getUser(login, password);
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
                        window = new Windows.ProductIC();
                        break;
                    default:
                        //window = new Windows.ProductsManager(); //это гость
                        window = new Windows.ProductIC();//это гость
                        break;
                }
                window.ShowDialog();
            }
        }
    }
}
