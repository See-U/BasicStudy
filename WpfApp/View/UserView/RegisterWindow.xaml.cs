using System;
using System.Linq;
using System.Windows;
using WpfApp.Model;

namespace WpfApp.View.UserView
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
            if (string.IsNullOrEmpty(this.PhoneTextBox.Text))
            {
                MessageBox.Show("手机号码不可以为空！");
                return;
            }
            else if(this.PhoneTextBox.Text.Length != 11)
            {
                MessageBox.Show("手机号码应为11位！");
                return;
            }
            try
            {
                using (WpfContext _context = new WpfContext())
                {
                    _context.Database.EnsureCreated();
                    var userItem = _context.Users.Where(x => x.UserName == this.UserNameTextBox.Text.ToLower()).FirstOrDefault();
                    if (userItem != null)
                    {
                        MessageBox.Show($"用户【{this.UserNameTextBox.Text}】已注册！");
                        return;
                    }
                    userItem = _context.Users.Where(x => x.Phone == this.PhoneTextBox.Text).FirstOrDefault();
                    if (userItem != null)
                    {
                        MessageBox.Show($"手机号码【{this.PhoneTextBox.Text}】已被注册！");
                        return;
                    }
                    User user = new User()
                    {
                        UserName = this.UserNameTextBox.Text,
                        PassWord = this.PasswordBox.Password,
                        Phone = this.PhoneTextBox.Text,
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    MessageBox.Show($"注册成功！");
                    this.Close();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
