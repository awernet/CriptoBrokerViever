namespace MexcApi.Responses.Futures
{
    public class FuturesContractTicker
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
        public ulong timestamp { get; set; }
    }
}
