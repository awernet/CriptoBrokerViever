using CriptoBrokerViewer.JsonClasses;
using System;
using System.Collections.Generic;

namespace CriptoBrokerViewer.Indicators
{
    sealed class RsiIndicator
    {
        private decimal averageGain;
        private decimal averageLoss;

        private void CalculateMoving(List<Candle> candles, int period = 14)
        {
            if (candles.Count < period)
                throw new ArgumentException("Недостаточно данных для расчета RSI.");

            averageGain = 0;
            averageLoss = 0;

            decimal gainSum = 0;
            decimal lossSum = 0;

            for (int i = 1; i < period; i++)
            {
                decimal change = candles[i].close - candles[i - 1].close;
                if (change > 0)
                    gainSum += change;
                else
                    lossSum -= change;
            }

            averageGain = gainSum / period;
            averageLoss = lossSum / period;
        }
        public decimal CalculateRsiWithWilderSmoothing(List<Candle> candles, int period = 14)
        {
            if (candles.Count < period)
                return 50;

            CalculateMoving(candles, period);

            for (int i = period; i < candles.Count; i++)
            {
                decimal change = candles[i].close - candles[i - 1].close;
                decimal gain = change > 0 ? change : 0;
                decimal loss = change < 0 ? -change : 0;

                averageGain = (averageGain * (period - 1) + gain) / period;
                averageLoss = (averageLoss * (period - 1) + loss) / period;
            }
            if (averageLoss == 0) return 100;

            decimal rs = averageGain / averageLoss;
            decimal rsi = 100 - (100 / (1 + rs));

            return Math.Round(rsi, 2);
        }
        public decimal CalculateRsiWithSMA(List<Candle> candles, int period = 14)
        {
            CalculateMoving(candles, period);

            decimal rs = averageLoss == 0 ? 0 : averageGain / averageLoss;
            decimal rsi = 100 - (100 / (1 + rs));

            return Math.Round(rsi, 2);
        }
    }
}
