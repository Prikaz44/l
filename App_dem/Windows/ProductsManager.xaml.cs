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
using System.Windows.Shapes;

namespace App_dem.Windows
{
    public partial class ProductsManager : Window
    {
        private List<Товары> _allProducts;
        private List<Товары> _filteredProducts;

        public ProductsManager()
        {
            InitializeComponent();
            icProducts.ItemsSource = DataBase.Сontext.Товары.ToList();

            txtCurrentUser.Text = User.lastUser.ФИО;

            LoadProducts(); // Загружаем все товары
            LoadSuppliers(); // Загружаем список поставщиков для фильтра

            txtSearchText.TextChanged += TxtSearchText_TextChanged;
            cmbSuppliers.SelectionChanged += CmbSuppliers_SelectionChanged;
        }

        private void LoadProducts()
        {
            _allProducts = DataBase.Сontext.Товары.ToList();
            _filteredProducts = new List<Товары>(_allProducts);
            icProducts.ItemsSource = _filteredProducts;
        }

        private void LoadSuppliers()
        {
            var suppliers = _allProducts
                .Where(p => !string.IsNullOrEmpty(p.Поставщик))
                .Select(p => p.Поставщик)
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            suppliers.Insert(0, "Все поставщики");

            cmbSuppliers.ItemsSource = suppliers;
            cmbSuppliers.SelectedIndex = 0;
        }

        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchText = txtSearchText.Text?.ToLower().Trim() ?? "";
            string selectedSupplier = cmbSuppliers.SelectedItem?.ToString();

            /*
             _allProducts - это список всех товаров 
            .AsEnumerable() - преобразует список в перечисляемую коллекцию
            Переменная query будет хранить запрос на фильтрацию

             */
            var query = _allProducts.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchText)) //Проверяет, что стрка поиска не пустая и не состоит только из пробелов
            {
                //Разбивает поисковый запрос на отдельные слова
                var terms = searchText.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries); 
                //Фильтрует коллекцию, оставляя только те товары, которые удовлетворяют условию
                query = query.Where(p => terms.All(t =>
                    $"{p.Артикул} {p.Наименование_товара} {p.Единица_измерения} {p.Поставщик} {p.Производитель} {p.Категория_товара} {p.Описание_товара}"
                        .ToLower()
                        .Contains(t)
                ));
            }

            if (!string.IsNullOrEmpty(selectedSupplier) && selectedSupplier != "Все поставщики")
            {
                query = query.Where(p => p.Поставщик == selectedSupplier);
            }

            _filteredProducts = query.ToList();
            ApplyCurrentSort();
        }

        private void ApplyCurrentSort()
        {
            var selectedRadio = FindSelectedSortRadio(); // Получаем выбранную радио-кнопку для сортировки

            if (selectedRadio != null)
            {
                switch (selectedRadio.Content.ToString())
                {
                    case "А-Я":
                        _filteredProducts = _filteredProducts
                            .OrderBy(p => p.Кол_во_на_складе)
                            .ToList();
                        break;
                    case "Я-А":
                        _filteredProducts = _filteredProducts
                            .OrderByDescending(p => p.Кол_во_на_складе)
                            .ToList();
                        break;
                }
            }

            icProducts.ItemsSource = null;
            icProducts.ItemsSource = _filteredProducts;
        }

        private RadioButton FindSelectedSortRadio()
        {
            foreach (var child in ((StackPanel)cmbSuppliers.Parent).Children)
            {
                if (child is RadioButton rb && rb.IsChecked == true)
                {
                    return rb;
                }
            }
            return null;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ApplyCurrentSort();
        }

        private void btnExitUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
