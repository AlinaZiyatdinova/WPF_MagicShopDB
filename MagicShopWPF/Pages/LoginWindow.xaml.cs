using MagicShopWPF.Models;
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
using System.Windows.Threading;

namespace MagicShopWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            textbox_loginInput.Focus();
            timer.Tick += Timer_Tick;
        }
        private DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1),
            IsEnabled = false
        };
        private int blockTime = 10;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (blockTime == 0)
            {
                unblockWindow();
                return;
            }

            button_Login.Content = blockTime.ToString();
            blockTime--;
        }
        private void button_Login_Click(object sender, RoutedEventArgs e)
        {
            string login_text = textbox_loginInput.Text;
            string password_text = textbox_passwordInput.Password;
            if (login_text != string.Empty && password_text != string.Empty)
            {
                var context = new MagicShopContext();
                string currentCaptcha = captchaFirstBlock.Text + captchaSecondBlock.Text;

                if (textbox_captchaInput.Text.Trim() != currentCaptcha)
                {
                    MessageBox.Show("Символы с картинки введены неверно", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    updateCaptcha();
                    updateFields();
                    return;
                }

                var mage = context.Mages.FirstOrDefault(p => p.Login == login_text.Trim() && p.Password == password_text.Trim());

                if (mage is null)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (captchaContainer.Visibility != Visibility.Hidden)
                    {
                        blockWindow();
                    }
                    updateCaptcha();
                    updateFields();
                    return;
                }
                else
                {
                    MessageBox.Show("Успешный вход", "Вход", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    var mageStatusID = mage.RoleId;
                    var mageStatusName = string.Empty;
                    foreach (MageRole mageRole in context.MageRoles.Where(r => r.RoleId == mageStatusID))
                    {
                        mageStatusName = mageRole.RoleName;
                    }
                    ProductWindow window = new ProductWindow(mage.Login); ;
                    window.Show();
                    Close();
                    updateFields();
                }
            }
        }
        private void updateFields()
        {
            textbox_loginInput.Text = string.Empty;
            textbox_passwordInput.Password = string.Empty;
            textbox_captchaInput.Text = string.Empty;
        }
        private void blockWindow()
        {
            IsEnabled = false;
            blockTime = 10;
            timer.Start();
        }
        private void unblockWindow()
        {
            timer.Stop();
            IsEnabled = true;
            button_Login.Content = "Войти";
        }
        private void updateCaptcha()
        {
            List<String> captchaWords = new List<string>() { "абра", "кадабра", "сим", "салабим", "фокус", "покус", "вжух", "ууу" };

            var rng = new Random();

            captchaFirstBlock.Text = $"{captchaWords[rng.Next(captchaWords.Count)]}{captchaWords[rng.Next(captchaWords.Count)]}";
            captchaSecondBlock.Text = $"{captchaWords[rng.Next(captchaWords.Count)]}{captchaWords[rng.Next(captchaWords.Count)]}";
            captchaSecondBlock.Margin = new Thickness(0, rng.Next(-10, 10), rng.Next(-10, 10), 0);
            captchaContainer.Visibility = Visibility.Visible;
        }
    }
}
