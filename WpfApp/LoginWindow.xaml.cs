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
using WpfApp.Common;

namespace WpfApp
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            IntialData();
        }

        private void Exit_Login(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Login(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tb_UserName.Text))
            {
                MessageBox.Show("用户名不可以为空！");
            }
            else if (string.IsNullOrEmpty(this.tb_PassWord.Password))
            {
                MessageBox.Show("密码不可以为空！");
            }
            else
            {
                if (this.cb_IsRemember.IsChecked == true)
                {
                    Utils.SetPropertyValue("IsRemember", true);
                    Utils.SetPropertyValue("UserName", this.tb_UserName.Text);
                    Utils.SetPropertyValue("PassWord", this.tb_PassWord.Password);
                }
                else
                {
                    Utils.SetPropertyValue("IsRemember", false);
                    Utils.SetPropertyValue("UserName", "");
                    Utils.SetPropertyValue("PassWord", "");
                }
                MessageBox.Show("登录成功！");
                MainWindow mainWindow = new MainWindow(this.tb_UserName.Text);
                mainWindow.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void IntialData()
        {
            this.tb_UserName.Text = Utils.GetPropertyValue("UserName").ToString();
            this.tb_PassWord.Password = Utils.GetPropertyValue("PassWord").ToString();
            this.cb_IsRemember.IsChecked = bool.TryParse(Utils.GetPropertyValue("IsRemember").ToString(),out bool val)? val:false;
        }

        private void Btn_Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void ForgetPsw_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
