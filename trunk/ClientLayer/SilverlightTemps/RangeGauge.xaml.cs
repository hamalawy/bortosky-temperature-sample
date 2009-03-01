using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightTemps
{
    public partial class RangeGauge : UserControl
    {
        const double GaugeMin = -20;
        const double GaugeMax = 110;
        public RangeGauge()
        {
            InitializeComponent();
            this.ThumbRectangle.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        public double GaugeWidth
        {
            get { return (double)GetValue(GaugeWidthProperty); }
            set { SetValue(GaugeWidthProperty, value); this.GridBorder.Width = value; }
        }

        public static readonly DependencyProperty GaugeWidthProperty = DependencyProperty.Register("GaugeWidth", typeof(double), typeof(RangeGauge), new PropertyMetadata(Convert.ToDouble(300)));

        private TemperatureDay subject;
        public TemperatureDay SubjectTemperatureDay
        {
            get { return this.subject; }
            set
            {
                this.subject = value;
                RedrawThumb();
            }
        }

        void RedrawThumb()
        {
            if (subject != null)
            {
                double GaugeDegrees = GaugeMax - GaugeMin;
                this.GridBorder.Width = this.GaugeWidth;
                this.ThumbTranslate.X = (((subject.MinTemperature - GaugeMin) / GaugeDegrees) * this.GridBorder.Width);
                this.ThumbRectangle.Width = (((subject.MaxTemperature - subject.MinTemperature) / GaugeDegrees) * this.GridBorder.Width);
            }
        }
    }
}
