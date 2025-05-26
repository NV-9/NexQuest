
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace NexQuestGui.ViewModels;
public class DashboardViewModel
{
    public SeriesCollection PieSeries { get; set; }
    public SeriesCollection BarSeries { get; set; }
    public List<string> Labels { get; set; }
    public AxesCollection XAxes { get; set; }
    public AxesCollection YAxes { get; set; }

    public DashboardViewModel()
    {
        PieSeries = new SeriesCollection
        {
            new PieSeries { Title = "Completed", Values = new ChartValues<double> { 30 }, DataLabels = true },
            new PieSeries { Title = "Pending", Values = new ChartValues<double> { 70 }, DataLabels = true }
        };

        BarSeries = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Activity",
                Values = new ChartValues<double> { 5, 3, 8, 2, 4, 3, 1 }
            }
        };

        Labels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        XAxes = new AxesCollection
        {
            new Axis
            {
                Title = "Days",
                Labels = Labels
            }
        };

        YAxes = new AxesCollection
        {
            new Axis
            {
                Title = "Count"
            }
        };
    }
}
