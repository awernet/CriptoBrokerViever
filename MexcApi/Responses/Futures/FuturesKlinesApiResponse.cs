using System.Collections.Generic;

namespace MexcApi.Responses.Futures
{
    public class FuturesKlinesApiResponse
    {
        public List<int> time { get; set; }
        public List<decimal> open { get; set; }
        public List<decimal> close { get; set; }
        public List<decimal> high { get; set; }
        public List<decimal> low { get; set; }
        public List<decimal> vol { get; set; }
        public List<decimal> amount { get; set; }
    }
}
