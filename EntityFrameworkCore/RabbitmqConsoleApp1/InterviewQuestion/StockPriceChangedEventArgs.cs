using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.InterviewQuestion
{
    public class StockPriceChangedEventArgs : EventArgs
    {
        public string StockSymbol { get; }
        public decimal NewPrice { get; }

        public StockPriceChangedEventArgs(string stockSymbol, decimal newPrice)
        {
            StockSymbol = stockSymbol;
            NewPrice = newPrice;
        }
    }
}
