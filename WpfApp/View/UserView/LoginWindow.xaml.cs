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
        private bool _IsLoading = false;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
                NotifyPropertyChange("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        
        }

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

        private  void Btn_Login(object sender, RoutedEventArgs e)
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
                IsLoading = true;
                using (var db = new WpfContext())
                {
                    var user = db.Users.Where(u => u.UserName.Equals(this.tb_UserName.Text)).FirstOrDefault();
                    if (user == null)
                    {
                        MessageBox.Show($"用户【{this.tb_UserName.Text}】不存在！");
                        return;
                    }
                    else
                    {
                        if (!user.PassWord.Equals(this.tb_PassWord.Password))
                        {
                            MessageBox.Show("用户密码错误！");
                            return;
                        }
                    }
                }
                IsLoading = false;

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
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
            this.Close();
        }

        private void ForgetPsw_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
