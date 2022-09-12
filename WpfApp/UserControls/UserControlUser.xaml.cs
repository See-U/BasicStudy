using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfApp.Model;

namespace WpfApp.UserControls
{
    /// <summary>
    /// UserControlUser.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlUser : UserControl
    {
        private CollectionViewSource userViewSource;
        public UserControlUser()
        {
            InitializeComponent();
            userViewSource =
               (CollectionViewSource)FindResource(nameof(userViewSource));
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (var _context = new WpfContext())
            {
                _context.Database.EnsureCreated();
                _context.Users.Load();

                // bind to the source
                userViewSource.Source =
                    _context.Users.Local.ToObservableCollection();
            }
        }
    }
}
