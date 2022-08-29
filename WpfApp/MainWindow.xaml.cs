using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 5;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string userName)
        {
            InitializeComponent();
            this.tb_CurUser.Text = $"当前用户：{userName}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                MessageBox.Show($"你戳了我一下，你还有{counter}次机会戳我！");
            }
            else
            {
                MessageBox.Show($"你没有机会戳我咯！");
            }
        }

        private void btn_LogOut(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
