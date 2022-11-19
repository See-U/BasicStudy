using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using WpfApp.Model;
using WpfApp.ViewModel;

namespace WpfApp.Common
{
    /// <summary>
    /// GlobalModel
    /// </summary>
    public class GlobalModel : BaseViewModel
    {
        public static GlobalModel Instance { get; set; } = new GlobalModel();

        private string _CurUserName = "未登录";
        public string CurUserName
        {
            get => _CurUserName;
            set
            {
                if (_CurUserName != value)
                {
                    _CurUserName = value;
                    OnPropertyChanged(); // reports this property
                }
            }

        }

        private User _CurUser = new User() { UserName = "未登录" };
        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurUser
        {
            get
            {
                if (_CurUser == null)
                {
                    _CurUser = new User();
                }

                return _CurUser;
            }
            set
            {
                if (_CurUser != value)
                {
                    _CurUser = value;
                    OnPropertyChanged(); // reports this property
                }
            }

        }
    }
}
