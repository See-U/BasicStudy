using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.Command
{
    /// <summary>
    /// WpfCommand
    /// </summary>
    public class WpfCommand : ICommand
    {
        /// <summary>
        /// 命令能否执行
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// 命令执行的方法
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// 命令的构造函数
        /// </summary>
        /// <param name="action">命令需执行的方法</param>
        /// <param name="canExecute">命令是否可以执行的方法</param>
        public WpfCommand(Action<object> action, Func<bool> canExecute)
        {
            _execute = action;
            _canExecute = canExecute;
        }

  
        /// <summary>
        /// 事件追加、移除
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// 判断命令是否可以执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute();
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
