using LearningConsoleApp;
using LearningConsoleApp.AccessAPI;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.Office.Interop.Excel;
using System.Text.Json.Nodes;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Azure.Core;
using System.Runtime.ConstrainedExecution;
using LearningConsoleApp.InterviewQuestion;
class Program
{
 
    static async Task Main(string[] args)
    {

        CriderCard[] cars = new CriderCard[]
    {
        new CriderCard()
        {
            Name = "Rewardscard"
        }, new CriderCard()
        {
            Name = "Balancetransfercard"
        }, new CriderCard()
        {
            Name = "Cashbackcredit"
        }
    };
       

        Array.Sort(cars);
        Array.ForEach(cars, x => Console.WriteLine(x.Name));

        // Create a new stock instance
        Stock appleStock = new Stock("AAPL", 150.00m);

        // Subscribe multiple investors to the stock price change event
        appleStock.StockPriceChanged += Investor1_StockPriceChanged;
        appleStock.StockPriceChanged += Investor2_StockPriceChanged;

        Console.ReadLine();
        // Simulate stock price changes
        appleStock.Price = 155.00m;
        appleStock.Price = 160.00m;

    }

    // Event handler method for Investor 1
    private static void Investor1_StockPriceChanged(object sender, StockPriceChangedEventArgs e)
    {
        Console.WriteLine($"Investor 1: The price of {e.StockSymbol} changed to {e.NewPrice:C}");
    }

    // Event handler method for Investor 2
    private static void Investor2_StockPriceChanged(object sender, StockPriceChangedEventArgs e)
    {
        Console.WriteLine($"Investor 2: The price of {e.StockSymbol} changed to {e.NewPrice:C}");
    }
}