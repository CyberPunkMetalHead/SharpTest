using ExchangeSharp;
using Sharptest;


var exchange = new Exchange();
var marketSymbols = exchange.GetExchangeInfo().Result;
var depositDetails = await exchange.GetDepositDetails("Ethereum");

Console.WriteLine(depositDetails);

foreach (var symbol in marketSymbols)
{
    Console.WriteLine($"Symbol: {symbol.MarketSymbol}, PriceStepSize: {symbol.PriceStepSize}, QuantityStepSize: {symbol.QuantityStepSize}");
}

ExchangeOrderRequest buyOrder = new()
{
    MarketSymbol = "SOLUSDT",
    Amount = 0.1m,        
    Price = null,        
    StopPrice = 0.0m, 
    IsBuy = true,     
    IsMargin = false,
    OrderId = null,
    ClientOrderId = null,
    ShouldRoundAmount = true,
    OrderType = OrderType.Market, 
    IsPostOnly = null,
};

Console.WriteLine(await exchange.GetExchangeInfo());

await exchange.Buy(buyOrder);

await Task.Delay(5000);

