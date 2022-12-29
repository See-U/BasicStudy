using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp.UserControls
{
    /// <summary>
    /// UserControlDemo.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlDemo : UserControl
    {
        public UserControlDemo()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<Member> members= new ObservableCollection<Member>();

            //创建数据表格项信息
            members.Add(new Member { Number = "1", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "张飞", Position = "教练", Email = "Zhangfei@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "2", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "关羽", Position = "管理员", Email = "Guanyu@hotmail.com", Phone = "425-768-9802" });
            members.Add(new Member { Number = "3", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "赵子龙", Position = "管理员", Email = "Zhaozilong@gmail.com", Phone = "320-3332-9087" });
            members.Add(new Member { Number = "4", Character = "J", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "姜子牙", Position = "经理", Email = "Jiangziya@gmail.com", Phone = "443-212-0932" });
            members.Add(new Member { Number = "5", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "曹操", Position = "教练", Email = "Caocao@hotmail.com", Phone = "412-091-0029" });
            members.Add(new Member { Number = "6", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "周瑜", Position = "教练", Email = "Zhouyu@gmail.com", Phone = "123-234-4432" });
            members.Add(new Member { Number = "7", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "黄盖", Position = "管理员", Email = "Huanggai@hotmail.com", Phone = "231-232-0931" });
            members.Add(new Member { Number = "8", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "钟馗", Position = "管理员", Email = "Zhongkui@gmail.com", Phone = "443-123-3123" });
            members.Add(new Member { Number = "9", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "曹植", Position = "教练", Email = "Caozhi@gmail.com", Phone = "412-990-3041" });
            members.Add(new Member { Number = "10", Character = "H", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "黄忠", Position = "教练", Email = "Huangzhong@hotmail.com", Phone = "324-213-2213" });

            members.Add(new Member { Number = "11", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "张飞", Position = "教练", Email = "Zhangfei@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "12", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "关羽", Position = "管理员", Email = "Guanyu@hotmail.com", Phone = "425-768-9802" });
            members.Add(new Member { Number = "13", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "赵子龙", Position = "管理员", Email = "Zhaozilong@gmail.com", Phone = "320-3332-9087" });
            members.Add(new Member { Number = "14", Character = "J", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "姜子牙", Position = "经理", Email = "Jiangziya@gmail.com", Phone = "443-212-0932" });
            members.Add(new Member { Number = "15", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "曹操", Position = "教练", Email = "Caocao@hotmail.com", Phone = "412-091-0029" });
            members.Add(new Member { Number = "16", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "周瑜", Position = "教练", Email = "Zhouyu@gmail.com", Phone = "123-234-4432" });
            members.Add(new Member { Number = "17", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "黄盖", Position = "管理员", Email = "Huanggai@hotmail.com", Phone = "231-232-0931" });
            members.Add(new Member { Number = "18", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "钟馗", Position = "管理员", Email = "Zhongkui@gmail.com", Phone = "443-123-3123" });
            members.Add(new Member { Number = "19", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "曹植", Position = "教练", Email = "Caozhi@gmail.com", Phone = "412-990-3041" });
            members.Add(new Member { Number = "20", Character = "H", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "黄忠", Position = "教练", Email = "Huangzhong@hotmail.com", Phone = "324-213-2213" });

            members.Add(new Member { Number = "21", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "张飞", Position = "教练", Email = "Zhangfei@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "22", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "关羽", Position = "管理员", Email = "Guanyu@hotmail.com", Phone = "425-768-9802" });
            members.Add(new Member { Number = "23", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "赵子龙", Position = "管理员", Email = "Zhaozilong@gmail.com", Phone = "320-3332-9087" });
            members.Add(new Member { Number = "24", Character = "J", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "姜子牙", Position = "经理", Email = "Jiangziya@gmail.com", Phone = "443-212-0932" });
            members.Add(new Member { Number = "25", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "曹操", Position = "教练", Email = "Caocao@hotmail.com", Phone = "412-091-0029" });
            members.Add(new Member { Number = "26", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "周瑜", Position = "教练", Email = "Zhouyu@gmail.com", Phone = "123-234-4432" });
            members.Add(new Member { Number = "27", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "黄盖", Position = "管理员", Email = "Huanggai@hotmail.com", Phone = "231-232-0931" });
            members.Add(new Member { Number = "28", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "钟馗", Position = "管理员", Email = "Zhongkui@gmail.com", Phone = "443-123-3123" });
            members.Add(new Member { Number = "29", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "曹植", Position = "教练", Email = "Caozhi@gmail.com", Phone = "412-990-3041" });
            members.Add(new Member { Number = "30", Character = "H", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "黄忠", Position = "教练", Email = "Huangzhong@hotmail.com", Phone = "324-213-2213" });

            members.Add(new Member { Number = "31", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "张飞", Position = "教练", Email = "Zhangfei@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "32", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "关羽", Position = "管理员", Email = "Guanyu@hotmail.com", Phone = "425-768-9802" });
            members.Add(new Member { Number = "33", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "赵子龙", Position = "管理员", Email = "Zhaozilong@gmail.com", Phone = "320-3332-9087" });
            members.Add(new Member { Number = "34", Character = "J", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "姜子牙", Position = "经理", Email = "Jiangziya@gmail.com", Phone = "443-212-0932" });
            members.Add(new Member { Number = "35", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "曹操", Position = "教练", Email = "Caocao@hotmail.com", Phone = "412-091-0029" });
            members.Add(new Member { Number = "36", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "周瑜", Position = "教练", Email = "Zhouyu@gmail.com", Phone = "123-234-4432" });
            members.Add(new Member { Number = "37", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "黄盖", Position = "管理员", Email = "Huanggai@hotmail.com", Phone = "231-232-0931" });
            members.Add(new Member { Number = "38", Character = "Z", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "钟馗", Position = "管理员", Email = "Zhongkui@gmail.com", Phone = "443-123-3123" });
            members.Add(new Member { Number = "39", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "曹植", Position = "教练", Email = "Caozhi@gmail.com", Phone = "412-990-3041" });
            members.Add(new Member { Number = "40", Character = "H", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "黄忠", Position = "教练", Email = "Huangzhong@hotmail.com", Phone = "324-213-2213" });
            //this.DataContext = members;
            membersDatagrid.ItemsSource = members;
        }
    }

    public class Member 
    {
        public string Character { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Brush BgColor { get; set; }
    }

}
