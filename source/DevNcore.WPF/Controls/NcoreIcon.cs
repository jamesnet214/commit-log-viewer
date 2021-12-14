using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevNcore.WPF.Controls
{
    internal class NcoreIcon : Control
    {
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register(
                "Data", 
                typeof(Geometry), 
                typeof(NcoreIcon), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register(
                "Fill",
                typeof(Brush), 
                typeof(NcoreIcon), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register(
                "Stroke", 
                typeof(Brush), 
                typeof(NcoreIcon), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty StrokeThicknessProperty = 
            DependencyProperty.Register(
                "StrokeThickness", 
                typeof(Thickness), 
                typeof(NcoreIcon),
                new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register(
                "CornerRadius", 
                typeof(CornerRadius), 
                typeof(NcoreIcon), 
                new PropertyMetadata(new CornerRadius(0, 0, 0, 0)));

        public static readonly DependencyProperty GeometryWidthProperty = 
            DependencyProperty.Register(
                "GeometryWidth", 
                typeof(double), 
                typeof(NcoreIcon),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty GeometryHeightProperty = 
            DependencyProperty.Register(
                "GeometryHeight", 
                typeof(double), 
                typeof(NcoreIcon), 
                new PropertyMetadata(0.0));

        public Geometry Data
        {
            get { return (Geometry)this.GetValue(DataProperty); }
            set { this.SetValue(DataProperty, value); }
        }

        public Brush Fill
        {
            get { return (Brush)this.GetValue(FillProperty); }
            set { this.SetValue(FillProperty, value); }
        }


        public Brush Stroke
        {
            get { return (Brush)this.GetValue(StrokeProperty); }
            set { this.SetValue(StrokeProperty, value); }
        }

        public Thickness StrokeThickness
        {
            get { return (Thickness)this.GetValue(StrokeThicknessProperty); }
            set { this.SetValue(StrokeThicknessProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)this.GetValue(CornerRadiusProperty); }
            set { this.SetValue(CornerRadiusProperty, value); }
        }

        public double GeometryWidth
        {
            get { return (double)this.GetValue(GeometryWidthProperty); }
            set { this.SetValue(GeometryWidthProperty, value); }
        }

        public double GeometryHeight
        {
            get { return (double)this.GetValue(GeometryHeightProperty); }
            set { this.SetValue(GeometryHeightProperty, value); }
        }
    }
}
