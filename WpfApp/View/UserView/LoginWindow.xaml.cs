using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfApp.Common;
using WpfApp.Model;
using WpfApp.ViewModel.Login;

namespace WpfApp.View.UserView
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginViewModel loginViewModel = new LoginViewModel();

        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = loginViewModel;
            IntialData();
        }

        private void Exit_Login(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void IntialData()
        {
            loginViewModel.CurUser.UserName = 
                this.tb_UserName.Text = Utils.GetPropertyValue("UserName").ToString();
            loginViewModel.CurUser.PassWord = 
                this.tb_PassWord.Password = Utils.GetPropertyValue("PassWord").ToString();
            loginViewModel.CurUser.IsRemember =
                this.cb_IsRemember.IsChecked = bool.TryParse(Utils.GetPropertyValue("IsRemember").ToString(),out bool val)? val:false;
        }

        private void Btn_Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
            this.Close();
        }

        private void ForgetPsw_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
