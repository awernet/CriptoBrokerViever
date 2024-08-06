using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.JsonClasses
{
    public class Candle
    {
        public Candle(decimal[] data)
        {
            time = Convert.ToInt32(data[0]);
            open = data[1];
            close = data[2];
            high = data[3];
            low = data[4];
            vol = data[5];
            amount = data[6];
        }
        public Candle() { }
        public int time { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal vol { get; set; }
        public decimal amount { get; set; }
    }
}
