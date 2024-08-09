using CriptoTraderHelper.Tools;
using Indicators;
using Loger;
using MexcApi;
using MexcApi.Entities;
using MexcApi.Responses.Futures;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CriptoTraderHelper.Strategies
{
    public class StrategyRsiAndChange
    {
        public StrategyRsiAndChange()
        {
            _api = new MexcAPI();
            _indicators = new IndicatorsManager();
        }

        private readonly MexcAPI _api;
        private readonly IndicatorsManager _indicators;
        public async Task ExecuteAsync(FuturesContractDetail contract)
        {
            //Получаем последние 15свечей для расчета RSI
            List<Candle> candles = await _api.FuturesApi.ContractKline(contract.symbol);
            //Получаем информацию для конкретного тикера
            FuturesContractTicker contractTicker = await _api.FuturesApi.ContractTicker(contract.symbol);
            //Расчитываем изменение и округляем его до 2ух знаков
            decimal riseFallRate = Math.Round(contractTicker.riseFallRate * 100, 2);
            //Расчитываем Rsi для текущего фьютчерса
            decimal rsi = _indicators.Rsi.CalculateRsiWithWilderSmoothing(candles);

            if (contract.maxLeverage > 74)
            {
                if (IsValidRSIRate(rsi, riseFallRate))
                {
                    //Рисуем и сохраняем график
                    Thread thread = new Thread(_ =>
                    {
                        OxyplotDrawerCandles oxyplotDrawerCandles = new OxyplotDrawerCandles(candles, $"images/{contract.baseCoin}{contract.quoteCoin}.png");
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                    ////////////////////////////
                    string message = $"${contract.baseCoin} | <a href =\"https://futures.mexc.com/exchange/{contract.baseCoin}_{contract.quoteCoin}?type=linear_swap\">MEXC</a> | <a href = \"https://www.tradingview.com/chart/?symbol={contract.indexOrigin[0].ToUpper()}:{contract.baseCoin}{contract.quoteCoin}\">TradingView</a>\n" +
                                $"--------------------------------------\n" +
                                $"<b>RSI:</b> {rsi}\n" +
                                $"<b>Price: {contractTicker.ask1}({riseFallRate}%)</b>\n" +
                                $"<b>Leverage:</b> {contract.maxLeverage}x\n" +
                                $"<b>volume24:</b> {StringConverter.ConvertNumberFromStringWithK(contractTicker.volume24)}\n";

                    //Events.InvokeMessageToTelegram(message, $"{contract.baseCoin}{contract.quoteCoin}");
                    LogVisualisator.Log(Loger.Enums.LogType.Warning, $"The message about {contract.baseCoin}{contract.quoteCoin} has been queued!");
                }
                else
                    LogVisualisator.Log(Loger.Enums.LogType.Info,$"{contract.symbol} rsi:{rsi} maxLeverage {contract.maxLeverage} riseFallRate: {riseFallRate}% skip...");
            }
        }

        private bool IsValidRSIRate(decimal rsi, decimal riseFallRate)
        {
            bool isValidRSI = rsi < 8 || rsi > 80;
            bool isValidRiseFallRate = riseFallRate < -8 | riseFallRate > 8;
            return isValidRSI && isValidRiseFallRate;
        }
    }
}
