using MaterialDesignThemes.Wpf;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.DataBase;
using WpfApp.resource;
using WpfApp.UserControls;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool MenuClosed = false;
        public MainWindow()
        {
            InitializeComponent();
            InitialMenu();
        }

        public MainWindow(string userName)
        {
            InitializeComponent();
            InitialMenu();
            this.CurUser.Header = userName;
        }


        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
                
            }
        }

        internal void UnSelectItem(SubItem subItem)
        {
            foreach (var item in Menu.Children)
            {
                if (((UserControlMenuItem)item).ListViewMenu.SelectedItem != null
                    && ((UserControlMenuItem)item).ListViewMenu.SelectedItem != subItem)
                {
                    ((UserControlMenuItem)item).ListViewMenu.UnselectAll();
                }
            }
        }

        private void InitialMenu()
        {

            var menuUser = new List<SubItem>()
               {
                   new SubItem("授权管理"),
                   new SubItem("资源管理"),
                   new SubItem("权限管理"),
                   new SubItem("角色管理",new UserControlRole()),
                   new SubItem("用户管理",new UserControlUser()),
               };
            var menuDemoExercise = new List<SubItem>()
               {
                   new SubItem("DemoExercise",new UserControlDemo())
               };
            var menuDataBase = new List<SubItem>()
               {
                   new SubItem("SQLiteDb",new UserControlSQLiteDb())
               };
            var UserPrivilegeItem = new ItemMenu("用户权限", menuUser, PackIconKind.Register);
            var demoExerciseItem = new ItemMenu("Demo练习", menuDemoExercise, PackIconKind.Excavator);
            var DataBaseItem = new ItemMenu("数据库", menuDataBase, PackIconKind.Excavator);

            Menu.Children.Add(new UserControlMenuItem(UserPrivilegeItem, this));
            Menu.Children.Add(new UserControlMenuItem(demoExerciseItem, this));
            Menu.Children.Add(new UserControlMenuItem(DataBaseItem, this));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                foreach (UserControlMenuItem item in this.Menu.Children)
                {
                    item.ExpanderMenu.Visibility = Visibility.Visible;
                }
                this.menuIcon.Kind = PackIconKind.HamburgerMenuBack;
                Storyboard openMenu = (Storyboard)button.FindResource("OpenMenu");
                openMenu.Begin();
            }
            else
            {
                foreach (UserControlMenuItem item in this.Menu.Children)
                {
                    item.ExpanderMenu.IsExpanded = false;
                    item.ExpanderMenu.Visibility = Visibility.Collapsed;
                }
                this.menuIcon.Kind = PackIconKind.HamburgerMenu;
                Storyboard closeMenu = (Storyboard)button.FindResource("CloseMenu");
                closeMenu.Begin();
            }

            MenuClosed = !MenuClosed;
        }

        private void Btn_MinSize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Btn_MaxSize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void Btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (this.CurUser.Header.ToString() != "未登录")
            {
                if (MessageBox.Show("退出登录?",
                    "退出",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // Do something here
                    this.CurUser.Header = "未登录";
                }
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Owner = this;
                loginWindow.ShowDialog();
            }
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
