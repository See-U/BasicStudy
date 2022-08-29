using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Common
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class Utils
    {
        #region  设置属性读写
        /// <summary>
        /// 读取设置属性值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetPropertyValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return Properties.Settings.Default[name];
        }

        /// <summary>
        /// 更改设置属性值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool SetPropertyValue(string name,object val)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                Properties.Settings.Default[name] = val;
                Properties.Settings.Default.Save();
            }
            
            return true;
        }

        #endregion

        #region  资源文件读取
        /// <summary>
        /// 读取资源文件值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object? GetResorcesValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return Properties.Resources.ResourceManager.GetObject(name);
        }

        #endregion
    }
}
