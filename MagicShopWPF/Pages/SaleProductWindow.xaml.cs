using MagicShopWPF.Models;
using Microsoft.EntityFrameworkCore;
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

namespace MagicShopWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для SaleProductWindow.xaml
    /// </summary>
    public partial class SaleProductWindow :Window
    {
        MagicProduct product;
        string login = string.Empty;
        Mage mage;
        public SaleProductWindow (MagicProduct product, string login)
        {
            InitializeComponent();
            this.product = product;
            this.login = login;
            DataContext = product;
            var context = new MagicShopContext();
            foreach (Mage mage in context.Mages.Where(c => c.Login == login))
            {
                this.mage = mage;
            }
            combobox_clientInfo.ItemsSource = context.Clients.ToList();
        }
        private void button_sellProduct_Click (object sender, RoutedEventArgs e)
        {
            if(textbox_amount.Text != string.Empty)
            {
                bool error = false;
                foreach(char c in textbox_amount.Text)
                {
                    if (!Char.IsNumber(c))
                    {
                        error = true;
                    }
                }
                if (error == false)
                {
                    int amount = Convert.ToInt32(textbox_amount.Text.Trim());
                    if (amount > product.Amount)
                    {
                        MessageBox.Show($"Введите количество от 1 до {product.Amount}", "Ошибка продажи", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (amount <= product.Amount && amount > 0)
                    {
                        Client? selectedClient = combobox_clientInfo.SelectedItem as Client;
                        Order order = new Order() { ProductId = product.Id, ClientId = selectedClient.ClientId, Amount = product.Amount - amount,
                            MageId = mage.MageId, Date = DateTime.Today};
                        using (var context = new MagicShopContext())
                        {
                            product.Amount = product.Amount - amount;
                            context.MagicProducts.Update(product);

                            context.Entry(order).State = EntityState.Added;

                            context.SaveChanges();

                            this.Close();
                            ProductWindow window = new ProductWindow(login);
                            window.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Вы ввели 0", "Ошибка продажи", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Некорректый ввод", "Ошибка продажи", MessageBoxButton.OK, MessageBoxImage.Error);
                }
             
            }
            else
            {
                MessageBox.Show($"Не все поля заполнены","Ошибка продажи",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_backPage_Click (object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow(login);
            window.Show();
        }

        private void Window_Closed (object sender, EventArgs e)
        {
            ProductWindow window = new ProductWindow(login);
            window.Show();
        }
    }
}
