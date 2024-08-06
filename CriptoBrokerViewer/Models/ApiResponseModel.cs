using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.Models
{
    //public class ApiResponseModel
    //{
    //    public bool success { get; set; }
    //    public int code { get; set; }
    //    public List<ContractModel> data { get; set; }
    //}
    /*public class CandlesModel
    {
        public bool success { get; set; }
        public int code { get; set; }
        public CandleData data { get; set; }

        public List<Candle> GetLastCandlesCount(CandleData data, int count = 14)
        {
            List<Candle> candles = new List<Candle>() ;
            int startIndex = data.close.Length - count - 1;
            int endIndex = data.close.Length-1;
            for (int i = endIndex; i > startIndex; i--)
            {
                Candle candle = new Candle()
                {
                    Time = data.time[i],
                    Open = data.open[i],
                    Close = data.close[i],
                    High = data.high[i],
                    Low = data.low[i],
                    Vol = data.vol[i],
                    Amount = data.amount[i]
                };
                candles.Add(candle);
            }
            return candles;
        }
    }
    public class CandleData
    {
        public int[] time { get; set; }
        public decimal[] open { get; set; }
        public decimal[] close { get; set; }
        public decimal[] high { get; set; }
        public decimal[] low { get; set; }
        public decimal[] vol { get; set; }
        public decimal[] amount { get; set; }
    }

    public class Candle
    {
        public int Time;
        public decimal Open;
        public decimal Close;
        public decimal High;
        public decimal Low;
        public decimal Vol;
        public decimal Amount;
    }
    /// <summary>
    /// /////////////////////
    /// </summary>
    public class ContractsDetails
    {
        public bool success { get; set; }
        public int code { get; set; }
        public List<Contract> data { get; set; }
    }

    public class Contract
    {
        public string symbol { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public int positionOpenType { get; set; }
        public string baseCoin { get; set; }
        public string quoteCoin { get; set; }
        public string settleCoin { get; set; }
        public double contractSize { get; set; }
        public int minLeverage { get; set; }
        public int maxLeverage { get; set; }
        public int priceScale { get; set; }
        public int volScale { get; set; }
        public int amountScale { get; set; }
        public decimal priceUnit { get; set; }
        public int volUnit { get; set; }
        public int minVol { get; set; }
        public int maxVol { get; set; }
        public double bidLimitPriceRate { get; set; }
        public double askLimitPriceRate { get; set; }
        public double takerFeeRate { get; set; }
        public double makerFeeRate { get; set; }
        public double maintenanceMarginRate { get; set; }
        public double initialMarginRate { get; set; }
        public int riskBaseVol { get; set; }
        public int riskIncrVol { get; set; }
        public double riskIncrMmr { get; set; }
        public double riskIncrImr { get; set; }
        public int riskLevelLimit { get; set; }
        public double priceCoefficientVariation { get; set; }
        public List<string> indexOrigin { get; set; }
        public int state { get; set; }
        public bool isNew { get; set; }
        public bool isHot { get; set; }
        public bool isHidden { get; set; }
        public List<string> conceptPlate { get; set; }
        public string riskLimitType { get; set; }
        public List<int> maxNumOrders { get; set; }
        public int marketOrderMaxLevel { get; set; }
        public double marketOrderPriceLimitRate1 { get; set; }
        public double marketOrderPriceLimitRate2 { get; set; }
        public double triggerProtect { get; set; }
        public int appraisal { get; set; }
        public int showAppraisalCountdown { get; set; }
        public int automaticDelivery { get; set; }
        public bool apiAllowed { get; set; }
    }*/

}
