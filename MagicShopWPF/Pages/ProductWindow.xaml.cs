using MagicShopWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicShopWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        string login = string.Empty;
        int? status_roleID = 0;
        Mage mage;
        public ProductWindow(string login_mage)
        {
            InitializeComponent();
            this.login = login_mage;

            var context = new MagicShopContext();
           
            foreach(Mage mage in context.Mages.Where(c=>c.Login == login_mage))
            {
                status_roleID = mage.RoleId;
                this.mage = mage;
            }
            DataContext = mage;

            if (status_roleID == 1)
            {
                productsListView.ItemsSource = context.MagicProducts.Include(p => p.Category).Where(c=>c.Category.Name == "Зелья").ToList();
            }
            else if (status_roleID == 2)
            {
                productsListView.ItemsSource = context.MagicProducts.Include(p => p.Category).Where(c => c.Category.Name != "Зелья").ToList();
                panel_filtration.Visibility = Visibility.Visible;
                panel_sorting.Visibility = Visibility.Visible;

                var category = context.Categories.ToList();
                category.Insert(0, new Category { CategoryId = 0, Name = "Все категории" });
                combobox_filtration.ItemsSource = category;


            }
            else if (status_roleID == 3)
            {
                while(true)
                {
                    var result = MessageBox.Show("Окно заколдовано древней магией. ВЫЙТИ?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                        break;
                    }
                }
            }
               
        }

        private void login_imageMage_MouseDown(object sender, MouseEventArgs e)
        {
            var context = new MagicShopContext();
            string info = string.Empty;
            foreach (Mage mage in context.Mages.Include(e=>e.Role).Where(r=>r.Login == login))
            {
                info += $"Пользователь: {mage.Login}\nРоль: {mage.Role.RoleName}";
            }
            MessageBox.Show($"{info}","Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            this.Close();
        }

        private void UpdateListView()
        {

            using (var context = new MagicShopContext())
            {

                var query = context.MagicProducts.Include(p => p.Category).AsQueryable();


                if (status_roleID == 1)
                {
                    var searchQuery = textbox_search.Text;
                    if (searchQuery!= string.Empty)
                    {
                        query = query.Where(c => c.Category.Name == "Зелья").Where(p => p.NameProduct.Contains(textbox_search.Text) || p.Description.Contains(textbox_search.Text));
                    }
                }
                else
                {
                    var searchQuery = textbox_search.Text;
                    if (searchQuery != string.Empty)
                    {
                        query = query.Where(c => c.Category.Name != "Зелья").Where(p => p.NameProduct.Contains(textbox_search.Text) || p.Description.Contains(textbox_search.Text));
                    }
                    
                    var selectedCategory = (Category)combobox_filtration.SelectedItem;
                    if (selectedCategory != null && selectedCategory.CategoryId != 0)
                    {
                        query = query.Where(p => p.CategoryId == selectedCategory.CategoryId);
                    }

                    switch (combobox_sorting.SelectedIndex)
                    {
                        case 1: // По возрастанию цены
                            query = query.OrderBy(p => p.Cost);
                            break;
                        case 2: // По убыванию цены
                            query = query.OrderByDescending(p => p.Cost);
                            break;
                    }
                }
                var filteredList = query.ToList();
                productsListView.ItemsSource = filteredList;
            }

        }
        private void textbox_search_TextChanged(object sender, TextChangedEventArgs e) => UpdateListView();

        private void combobox_sorting_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateListView();

        private void combobox_filtration_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateListView();

        private void productsListView_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            MagicProduct? selectedProduct = productsListView.SelectedItem as MagicProduct;
            if (productsListView.SelectedItems.Count > 0)
            {
                button_sell.IsEnabled = true;
            }
            else
            {
                button_sell.IsEnabled = false;
            }
        }

        private void button_sell_Click (object sender, RoutedEventArgs e)
        {
            MagicProduct? selectedProduct = productsListView.SelectedItem as MagicProduct;
            if (selectedProduct is not null)
            {
                if (selectedProduct.Amount > 0)
                {
                    this.Hide();
                    var window = new SaleProductWindow(selectedProduct, login);
                    window.Show();
                    UpdateListView();
                }
                else
                {
                    MessageBox.Show("Товара нет в наличии","Ошибка продажи",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Window_Closed (object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
