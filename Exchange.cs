using ExchangeSharp;

namespace Sharptest
{
    public class Exchange
    {
        private readonly IExchangeAPI _exchangeAPI;

        public Exchange(string key, string secret)
        {
            // Initialize the Exchange API within the constructor
            _exchangeAPI = ExchangeAPI.GetExchangeAPIAsync(ExchangeName.Coinbase).Result;
            _exchangeAPI.LoadAPIKeysUnsecure(key, secret);
        }

        public async Task<IEnumerable<ExchangeMarket>> GetExchangeInfo()
        {
            return await _exchangeAPI.GetMarketSymbolsMetadataAsync();
        }

        public async Task<ExchangeOrderResult?> Buy(ExchangeOrderRequest order)
        {
            ExchangeOrderResult? resp = null;
            try
            {
                resp = await _exchangeAPI.PlaceOrderAsync(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return resp;
        }

        public async Task<ExchangeDepositDetails> GetDepositDetails(string coin)
        {
            return await _exchangeAPI.GetDepositAddressAsync(coin);
        }

        public string NormalizeMarketSymbol(string marketSymbol)
        {
            return _exchangeAPI.NormalizeMarketSymbol(marketSymbol);
        }
    }
}
