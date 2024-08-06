using CriptoBrokerViewer.Api;
using CriptoBrokerViewer.Indicators;
using CriptoBrokerViewer.JsonClasses;
using CriptoBrokerViewer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WorkerSpace.WinUtils;


namespace CriptoBrokerViewer
{
    public class CoinsDataTask
    {
        public int Time = 300000;

        public delegate void ContractHandler(string message, string symbol);
        public static event ContractHandler Notify;
        public async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("Start!");
            try
            {
                MexcApi api = new MexcApi();
                RsiIndicator rsiIndicator = new RsiIndicator();

                List<ContractDetail> contracts = await api.Futures.ContractDetail();
                foreach (var contract in contracts)
                {
                    //Получаем последние 15свечей для расчета RSI
                    List<Candle> candles = await api.Futures.ContractKline(contract.symbol);
                    await Task.Delay(50);
                    //Получаем последнии 2 дня для расчета процента изменения
                    Ticker24h candlesDays = await api.SpotV3.Klines($"{contract.baseCoin}{ contract.quoteCoin}");
                    await Task.Delay(50);         

                    Ticker ticker = await api.SpotV2.MarketTicker(contract.symbol);
                    decimal rsi = rsiIndicator.CalculateRsiWithWilderSmoothing(candles);


                    if (contract.maxLeverage > 74)
                    {
                        
                        if (rsi > 82 || rsi < 8 || candlesDays.priceChangePercent > 8)
                        {  
                            Thread thread = new Thread(_ =>
                            {
                                CandleDrawer drawer = new CandleDrawer();
                                var plotModel = drawer.CreatePlotModel(candles);
                                drawer.SavePlotAsImage(plotModel, $"images/{contract.baseCoin}{contract.quoteCoin}.png");
                            });
                            thread.SetApartmentState(ApartmentState.STA);
                            thread.Start();
                            thread.Join();

                            ContractTicker contractTicker = await api.Futures.ContractTicker(contract.symbol);

                            string volume24h = string.Empty;
                            if (contractTicker.volume24 >= 1000)
                                volume24h = Math.Round((contractTicker.volume24 / 1000),0).ToString("0.##") + "k";
                            else
                                volume24h = contractTicker.volume24.ToString();

                            string message = $"${contract.baseCoin} | <a href =\"https://futures.mexc.com/exchange/{contract.baseCoin}_{contract.quoteCoin}?type=linear_swap\">MEXC</a> | <a href = \"https://www.tradingview.com/chart/?symbol={contract.indexOrigin[0].ToUpper()}:{contract.baseCoin}{contract.quoteCoin}\">TradingView</a>\n" +
                                $"--------------------------------------\n" +
                                $"<b>RSI:</b> {rsi}\n" +
                                $"<b>Price{contractTicker.ask1}({candlesDays.priceChangePercent}% in 24h)</b>\n" +
                                $"<b>Leverage:</b> {contract.maxLeverage}x\n" +
                                $"<b>volume24:</b> {volume24h}\n";
                            Notify?.Invoke(message, $"{contract.baseCoin}{contract.quoteCoin}");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(message);
                            //Console.WriteLine($"Name: {contract.symbol} riseFallValue: {contractTicker.riseFallRate} rsi {rsi}");
                            //Console.WriteLine($"Name: {contract.symbol} riseFallValue: {contractTicker.riseFallRate}");
                            // Console.WriteLine(rsi);
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine($"{contract.symbol} rsi:{rsi} maxLeverage {contract.maxLeverage} priceChangePercent: {candlesDays.priceChangePercent}% skip...");

                        await Task.Delay(20);

                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("End!");
            await Task.Delay(Time);
        }
    }
}
