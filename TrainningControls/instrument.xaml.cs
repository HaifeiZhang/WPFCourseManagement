using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrainningControls
{
    /// <summary>
    /// Interaction logic for instrument.xaml
    /// </summary>
    public partial class instrument : UserControl
    {
        //依赖属性，依赖对象



        public Brush PlateBackground
        {
            get { return (Brush)GetValue(PlateBackgroundProperty); }
            set { SetValue(PlateBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlateBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlateBackgroundProperty =
            DependencyProperty.Register("PlateBackground", typeof(Brush), typeof(instrument), new PropertyMetadata(default(Brush)));


        public double Value
        {
            get { return (double)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double),typeof(instrument),new PropertyMetadata(10.0, new PropertyChangedCallback(OnPropertyChanged)));




        public int ScaleTextSize
        {
            get { return (int)GetValue(ScaleTextSizeProperty); }
            set { SetValue(ScaleTextSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleTextSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleTextSizeProperty =
            DependencyProperty.Register("ScaleTextSize", typeof(int), typeof(instrument), new PropertyMetadata(10, new PropertyChangedCallback(OnPropertyChanged)));




        public Brush ScaleBrush
        {
            get { return (Brush)GetValue(ScaleBrushProperty); }
            set { SetValue(ScaleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleBrushProperty =
            DependencyProperty.Register("ScaleBrush", typeof(Brush), typeof(instrument), new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));



        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));



        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(instrument), new PropertyMetadata(100, new PropertyChangedCallback(OnPropertyChanged)));



        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Interval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(int), typeof(instrument), new PropertyMetadata(10, new PropertyChangedCallback(OnPropertyChanged)));





        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as instrument).Refresch();
        }

        public instrument()
        {
            InitializeComponent();
            this.SizeChanged += Instrument_SizeChanged;
        }

        private void Instrument_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double minSize = Math.Min(this.RenderSize.Height, this.RenderSize.Width);
            this.backEllipse.Width = minSize;
            this.backEllipse.Height = minSize;
        }

        private void Refresch()
        {
            double radius = this.backEllipse.Width / 2;
            if (double.IsNaN(radius))
            {
                return;
            }
            
            this.mainCanvas.Children.Clear();
            double step = 270.0 / (this.Maximum - this.Minimum);
            //double scaleAreaCount = 10;
            for (int i = 0; i < this.Maximum - this.Minimum; i++)
            {
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 13) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 13) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.Stroke = this.ScaleBrush;
                lineScale.StrokeThickness = 2;

                this.mainCanvas.Children.Add(lineScale);
            }
            step = 270.0 / this.Interval;
            int scaleText = this.Minimum;
            for (int i = 0; i <= this.Interval; i++)
            {
                //刻度
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 20) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 20) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.Stroke = this.ScaleBrush;
                lineScale.StrokeThickness = 2;

                this.mainCanvas.Children.Add(lineScale);

                //刻度值
                TextBlock textScale = new TextBlock();
                textScale.Width = 34;
                textScale.FontSize = this.ScaleTextSize;
                textScale.TextAlignment = TextAlignment.Center;
                textScale.Foreground = this.ScaleBrush;
                textScale.Text = (scaleText + (this.Maximum - this.Minimum) / this.Interval * i).ToString();
                Canvas.SetLeft(textScale, radius - (radius - 36) * Math.Cos((i * step - 45) * Math.PI / 180) - 17);
                Canvas.SetTop(textScale, radius - (radius - 36) * Math.Sin((i * step - 45) * Math.PI / 180) - 10);

                this.mainCanvas.Children.Add(textScale);

                //圆环
                string sData = "M{0} {1} A{0} {0} 0 1 1 {1} {2}";
                sData = string.Format(sData,radius/2,radius,radius*1.5);
                var converter = TypeDescriptor.GetConverter(typeof(Geometry));
                this.circle.Data = (Geometry)converter.ConvertFrom(sData);

                //添加动画
                //this.rtPointer.Angle = this.Value * (270 / (this.Maximum - this.Minimum))-45;

                DoubleAnimation da = new DoubleAnimation((this.Value-this.Minimum) * (270 / (this.Maximum - this.Minimum)) - 45, new Duration(TimeSpan.FromMilliseconds(200)));
                this.rtPointer.BeginAnimation(RotateTransform.AngleProperty,da);
                //指针
                sData = "M{0} {1}, {1} {2}, {1} {3}";
                sData = string.Format(sData, radius*0.3, radius, radius-5, radius+5);
                converter = TypeDescriptor.GetConverter(typeof(Geometry));
                this.pointer.Data = (Geometry)converter.ConvertFrom(sData);


            }
        }
    }
}
