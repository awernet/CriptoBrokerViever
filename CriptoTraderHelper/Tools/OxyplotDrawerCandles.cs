using MexcApi.Entities;
using OxyPlot.Series;
using OxyPlot;
using System.Collections.Generic;
using OxyPlot.WindowsForms;

namespace CriptoTraderHelper.Tools
{
    public class OxyplotDrawerCandles
    {
        public OxyplotDrawerCandles(List<Candle> data, string fileName) 
        {
            var plotModel = new PlotModel { Title = "", Background = OxyColor.FromRgb(0, 0, 0) };

            var series = new CandleStickSeries { Title = "Candles" };

            for (int i = 0; i < 200; i++)
            {
                double open = (double)data[i].open;
                double close = (double)data[i].close;
                double high = (double)data[i].high;
                double low = (double)data[i].low;

                series.Items.Add(new HighLowItem(i, high, low, open, close));
            }

            plotModel.Series.Add(series);

            var plotModelImage = new PngExporter { Width = 1920, Height = 1080 }.ExportToBitmap(plotModel);

            plotModelImage.Save(fileName);
            
        }
    }
}
