using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp.Command;
using WpfApp.Common;
using WpfApp.Model;

namespace WpfApp.ViewModel.Login
{
    /// <summary>
    /// LoginViewModel
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Property

        private Timer _timer;
        private DateTime _CurDateTime;
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurDateTime
        {
            get => _CurDateTime;
            set
            {
                if (_CurDateTime != value)
                {
                    _CurDateTime = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        private Visibility _IsLoading = Visibility.Hidden;
        /// <summary>
        /// 正在加载
        /// </summary>
        public Visibility IsLoading
        {
            get => _IsLoading;
            set
            {
                if (_IsLoading != value)
                {
                    _IsLoading = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        private User _CurUser;
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

        #endregion

        #region Command
        /// <summary>
        /// 登录命令要执行的方法
        /// </summary>
        async void LoginExecute(object obj)
        {
            if (string.IsNullOrEmpty(CurUser.UserName))
            {
                MessageBox.Show("用户名不可以为空！");
            }
            else if (string.IsNullOrEmpty(CurUser.PassWord))
            {
                MessageBox.Show("密码不可以为空！");
            }
            else
            {
                if (CurUser.IsRemember == true)
                {
                    Utils.SetPropertyValue("IsRemember", true);
                    Utils.SetPropertyValue("UserName", CurUser.UserName);
                    Utils.SetPropertyValue("PassWord", CurUser.PassWord);
                }
                else
                {
                    Utils.SetPropertyValue("IsRemember", false);
                    Utils.SetPropertyValue("UserName", "");
                    Utils.SetPropertyValue("PassWord", "");
                }

                IsLoading = Visibility.Visible;
                await Task.Factory.StartNew(() => {
                    using (var db = new WpfContext())
                    {
                        var user = db.Users.Where(u => u.UserName == CurUser.UserName).FirstOrDefault();
                        if (user == null)
                        {
                            MessageBox.Show($"用户【{CurUser.UserName}】不存在！");
                            return;
                        }
                        else
                        {
                            if (user.PassWord != CurUser.PassWord)
                            {
                                MessageBox.Show("用户密码错误！");
                                return;
                            }
                        }
                    }
                });
                

                GlobalModel.Instance.CurUserName =  CurUser.UserName;
                IsLoading = Visibility.Collapsed;
                //MessageBox.Show("登录成功！")Visibility.Collapsed;
                var window = obj as Window;
                if (window != null) { window.Close(); }
            }
        }

        /// <summary>
        /// 登录命令是否可以执行
        /// </summary>
        /// <returns></returns>
        bool CanLoginExecute()
        {
            return true;
        }

        /// <summary>
        /// 登录命令
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                return new WpfCommand(LoginExecute, CanLoginExecute);
               
            }
        }


        //private DelegateCommand<Window> _cancelCommand = null;

        //public DelegateCommand<Window> CancelCommand
        //{
        //    get
        //    {
        //        if (_cancelCommand == null)
        //        {
        //            _cancelCommand = new DelegateCommand<Window>(Cancel);
        //        }

        //        return _cancelCommand;
        //    }
        //}

        //void Cancel(Window window)
        //{
        //    if (window != null)
        //    {
        //        window.DialogResult = false;
        //        window.Close();
        //    }
        //}
        #endregion

        public LoginViewModel()
        {
            CurDateTime = DateTime.Now;

            // Update the DateTime property every second.
            _timer = new Timer(new TimerCallback((s) => CurDateTime = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        ~LoginViewModel() =>
     _timer.Dispose();

        #region private Method

        #endregion
    }
}
