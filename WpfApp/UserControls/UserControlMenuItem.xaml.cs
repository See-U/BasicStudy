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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModel;

namespace WpfApp.UserControls
{
    /// <summary>
    /// UserControlMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectitem = (SubItem)((ListView)sender).SelectedItem;
            _context.UnSelectItem(selectitem);
            if (selectitem != null)
            {
                _context.SwitchScreen(selectitem.Screen);
                //this.ListViewMenu.UnselectAll();
            }
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
