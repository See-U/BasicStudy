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
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.UserNameTextBox.Text))
            {
                MessageBox.Show("用户名不可为空！");
                return;
            }
            if (string.IsNullOrEmpty(this.PasswordBox.Password) ||
               string.IsNullOrEmpty(this.RePasswordBox.Password))
            {
                MessageBox.Show("密码不可为空！");
                return;
            }
            
            if (this.PasswordBox.Password != this.RePasswordBox.Password)
            {
                MessageBox.Show("两次输入密码不一致，请重新输入！");
                return;
            }
            try
            {
                using (WpfContext _context = new WpfContext())
                {
                    _context.Database.EnsureCreated();
                    User user = new User()
                    {
                        UserName = this.UserNameTextBox.Text,
                        PassWord = this.PasswordBox.Password,
                        Phone = this.PhoneTextBox.Text,
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show(); 
            this.Close();
        }
    }
}
