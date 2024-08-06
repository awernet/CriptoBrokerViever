using System.Collections.Generic;

namespace CriptoBrokerViewer.JsonClasses
{
    public class FutureResponse<T>
    {
        public bool success { get; set; }
        public int code { get; set; }
        public T data { get; set; }
    }

    public class Klines
    {
        public List<int> time { get; set; }
        public List<decimal> open { get; set; }
        public List<decimal> close { get; set; }
        public List<decimal> high { get; set; }
        public List<decimal> low { get; set; }
        public List<decimal> vol { get; set; }
        public List<decimal> amount { get; set; }
    }
    public class ContractTicker
    {
        public string symbol { get; set; }
        public decimal lastPrice { get; set; }
        public decimal bid1 { get; set; }
        public decimal ask1 { get; set; }
        public decimal volume24 { get; set; }
        public decimal amount24 { get; set; }
        public decimal holdVol { get; set; }
        public decimal lower24Price { get; set; }
        public decimal high24Price { get; set; }
        public decimal riseFallRate { get; set; }
        public decimal riseFallValue { get; set; }
        public decimal indexPrice { get; set; }
        public decimal fairPrice { get; set; }
        public decimal fundingRate { get; set; }
        public decimal maxBidPrice { get; set; }
        public decimal minAskPrice { get; set; }
        public decimal timestamp { get; set; }
    }
    public class ContractDetail
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
        public double priceUnit { get; set; }
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
    }
}
