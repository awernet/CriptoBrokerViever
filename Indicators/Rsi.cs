using MexcApi.Entities;
using System;
using System.Collections.Generic;

namespace Indicators
{
    public class Rsi
    {
        private decimal _averageGain;
        private decimal _averageLoss;
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

                _averageGain = (_averageGain * (period - 1) + gain) / period;
                _averageLoss = (_averageLoss * (period - 1) + loss) / period;
            }
            if (_averageLoss == 0) return 100;

            decimal rs = _averageGain / _averageLoss;
            decimal rsi = 100 - (100 / (1 + rs));

            return Math.Round(rsi, 2);
        }

        public decimal CalculateRsiWithSMA(List<Candle> candles, int period = 14)
        {
            CalculateMoving(candles, period);

            decimal rs = _averageLoss == 0 ? 0 : _averageGain / _averageLoss;
            decimal rsi = 100 - (100 / (1 + rs));

            return Math.Round(rsi, 2);
        }

        private void CalculateMoving(List<Candle> candles, int period = 14)
        {
            _averageGain = 0;
            _averageLoss = 0;

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

            _averageGain = gainSum / period;
            _averageLoss = lossSum / period;
        }
    }
}
