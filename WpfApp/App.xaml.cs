using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen("/resource/images/SplashScreen.png");
            bool flag = true;
            splashScreen.Show(flag);//flag为true时，程序启动完毕启动屏幕就会自动关闭；
                                    //flag为false,启动屏幕图片不会自动关闭，需要设置延时关闭，比如3秒
            splashScreen.Close(new TimeSpan(0,0,3)); 
            base.OnStartup(e);
        }
    }
}
