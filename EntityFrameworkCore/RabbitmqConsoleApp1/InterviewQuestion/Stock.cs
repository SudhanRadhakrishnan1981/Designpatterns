using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.InterviewQuestion
{
    public class Stock
    {
        // Delegate for stock price change event handler
        public delegate void StockPriceChangedHandler(object sender, StockPriceChangedEventArgs e);

        // Event for notifying stock price changes
        public event StockPriceChangedHandler StockPriceChanged;

        private decimal price;
        public string Symbol { get; }

        public Stock(string symbol, decimal initialPrice)
        {
            Symbol = symbol;
            price = initialPrice;
        }

        // Property for updating the stock price and raising the event
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnStockPriceChanged(new StockPriceChangedEventArgs(Symbol, value));
                }
            }
        }

        // Method for raising the stock price change event
        protected virtual void OnStockPriceChanged(StockPriceChangedEventArgs e)
        {
            StockPriceChanged?.Invoke(this, e);
        }
    }
}
