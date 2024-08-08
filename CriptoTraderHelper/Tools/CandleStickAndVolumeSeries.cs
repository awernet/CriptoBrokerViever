using OxyPlot.Series;
using OxyPlot;
using System.Collections.Generic;
using System.IO;
using MexcApi.Entities;
using System.Linq;
using System;
using OxyPlot.Axes;
using OxyPlot.Wpf;


namespace CriptoTraderHelper.Tools
{

    public class CandleStickAndVolumeSeries
    {
         public PlotModel Draw(List<Candle> data)
         {
             var pm = new PlotModel { Title = "Large Data Set (wide window)" };

             var timeSpanAxis1 = new DateTimeAxis { Position = AxisPosition.Bottom };
             pm.Axes.Add(timeSpanAxis1);
             var linearAxis1 = new LinearAxis { Position = AxisPosition.Left };
             pm.Axes.Add(linearAxis1);
             var series = new CandleStickSeries
             {
                 Color = OxyColors.Black,
                 IncreasingColor = OxyColors.DarkGreen,
                 DecreasingColor = OxyColors.Red,
                 DataFieldX = "time",
                 DataFieldHigh = "high",
                 DataFieldLow = "low",
                 DataFieldOpen = "open",
                 DataFieldClose = "close",
                 TrackerFormatString =
                                      "High: {2:0.00}\nLow: {3:0.00}\nOpen: {4:0.00}\nClose: {5:0.00}",
                 ItemsSource = data
             };

             pm.Series.Add(series);

             return pm;

         }

         public void SavePlotAsImage(PlotModel plotModel, string filePath)
         {
             using (var stream = new FileStream(filePath, FileMode.Create))
             {
                 var pngExporter = new OxyPlot.Wpf.PngExporter { Width = 1920, Height = 1080 };
                 pngExporter.Export(plotModel, stream);
             }
         }
    }
}
