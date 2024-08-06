
using CriptoBrokerViewer.JsonClasses;
using CriptoBrokerViewer.TelegramBot;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using WorkerSpace;
using WorkerSpace.Interfaces;
using WorkerSpace.Models;

namespace CriptoBrokerViewer
{
    internal class Application
    {
        [STAThread]
        static void Main(string[] args)
        {
                CLIBTask.CreateWorker("Main Worker");
                TaskBuilder taskBuilder = new TaskBuilder();

                CoinsDataTask coinsDataTask = new CoinsDataTask();

                taskBuilder.AppendExecuteDelegateFunc(coinsDataTask.Execute);

                ITask task = CLIBTask.NewTask(taskBuilder);



                TaskBuilder taskBuildertb = new TaskBuilder();

                TelegramSendler telegramSendler = new TelegramSendler();

                taskBuildertb.AppendExecuteDelegateFunc(telegramSendler.Execute);

                ITask task1 = CLIBTask.NewTask(taskBuildertb);

                /////////////////////////////////


                Process.GetCurrentProcess().WaitForExit();
        }

        public static PlotModel CreatePlotModel(List<Candle> data)
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

        public static void SavePlotAsImage(PlotModel plotModel, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var pngExporter = new OxyPlot.Wpf.PngExporter { Width = 800, Height = 600 };
                pngExporter.Export(plotModel, stream);
            }
        }
    }
}
