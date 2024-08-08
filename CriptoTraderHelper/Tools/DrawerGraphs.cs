using MexcApi.Entities;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System.Collections.Generic;
using System.IO;

namespace CriptoTraderHelper.Tools
{
    public class DrawerGraphs
    {
        public PlotModel CreatePlotModel(List<Candle> data)
        {
            var plotModel = new PlotModel { Title = "" };
            var lineSeries = new LineSeries();

            foreach (var candle in data)
            {
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(candle.time), (double)candle.close));
            }

            plotModel.Series.Add(lineSeries);
            return plotModel;
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
