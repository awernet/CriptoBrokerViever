using System.Collections.Generic;

namespace MexcApi.Responses.Futures
{
    public class FuturesContractDetail
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
