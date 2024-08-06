using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.JsonClasses
{
    public class MarketTickerTemplate
    {
        public int code { get; set; }
        public List<Ticker> data { get; set; }
    }

    public class Ticker
    {
        public string symbol { get; set; }
        public string volume { get; set; }
        public string amount { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string open { get; set; }
        public string last { get; set; }
        public long time { get; set; }
        public decimal change_rate { get; set; }
    }
}
