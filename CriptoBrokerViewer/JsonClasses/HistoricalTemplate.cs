using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.JsonClasses
{
    public class HistoricalDataTemplate
    {
        public int code { get; set; }
        public List<decimal[]> data { get; set; }
    }
}
