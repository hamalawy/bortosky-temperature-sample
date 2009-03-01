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
    public partial class Page : UserControl
    {
        private List<TemperatureDay> TempDays;
        private int selectedDayIndex;
        private TemperatureDay selectedDay;
        public Page()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
            this.NextBtn.Click += new RoutedEventHandler(NextBtn_Click);
            this.PrevBtn.Click += new RoutedEventHandler(PrevBtn_Click);
        }

        void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SelectedDayIndex--;
        }

        void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SelectedDayIndex++;
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataService.TemperatureDataService ds = new DataService.MockTemperatureDataService();
            ds.GetRecentTemperaturesComplete += new SilverlightTemps.DataService.TemperatureDataEventHandler(ds_GetRecentTemperaturesComplete);
            ds.GetRecentTemperaturesAsync("72434013994", 700);
        }

        void ds_GetRecentTemperaturesComplete(object sender, SilverlightTemps.DataService.TemperatureDataEventArgs e)
        {
            this.TempDays = e.TemperatureDays;
            if (this.TempDays.Count > 0)
            {
                this.SelectedDayIndex = TempDays.Count - 1;
            }
            this.LoadingPanel.Visibility = Visibility.Collapsed;
        }
        int SelectedDayIndex
        {
            get
            {
                return this.selectedDayIndex;
            }
            set
            {
                this.selectedDayIndex = value;
                this.selectedDay = TempDays[this.selectedDayIndex];
                this.DataContext = this.selectedDay;
                this.PrevBtn.IsEnabled = this.selectedDayIndex > 0;
                this.NextBtn.IsEnabled = this.selectedDayIndex < this.TempDays.Count() - 1;
                this.RangeGauge1.SubjectTemperatureDay = this.selectedDay;
                this.RangeGauge1.ThumbTransition.Begin();
                this.GrowTemps.Begin();
            }
        }
    }
}
