using ExchangeSharp;
using Sharptest;
using NLog;

var logger = LogManager.GetCurrentClassLogger();

// TODO put in you key/secret
var exchange = new Exchange("KEY_HERE", "SECRET_HERE");

ExchangeOrderRequest buyOrder =
    new()
    {
        MarketSymbol = exchange.NormalizeMarketSymbol("ada-usdt"),
        Amount = 1m,
        StopPrice = 0.0m,
        IsBuy = true,
        IsMargin = false,
        ShouldRoundAmount = true,
        OrderType = OrderType.Market,
    };

var result = await exchange.Buy(buyOrder);

logger.Info("Waiting 5 seconds for order to complete...");

await Task.Delay(3000);

logger.Warn($"Order Result: {result}");

logger.Error("Done!");
