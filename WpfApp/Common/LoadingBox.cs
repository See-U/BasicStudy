using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp.Common
{
    public class LoadingBox : Control
    {

        static LoadingBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingBox), new FrameworkPropertyMetadata(typeof(LoadingBox)));
        }

        public double RadiusX
        {
            get { return (double)GetValue(RadiusXProperty); }
            set { SetValue(RadiusXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadiusX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusXProperty =
            DependencyProperty.Register("RadiusX", typeof(double), typeof(LoadingBox), new PropertyMetadata(3d));



        public double RadiusY
        {
            get { return (double)GetValue(RadiusYProperty); }
            set { SetValue(RadiusYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadiusY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusYProperty =
            DependencyProperty.Register("RadiusY", typeof(double), typeof(LoadingBox), new PropertyMetadata(3d));

    }
}
