using ExchangeSharp;

namespace Sharptest
{
    public class Exchange
    {
        private readonly IExchangeAPI _exchangeAPI;
        public Exchange()
        {

            // Initialize the Exchange API within the constructor
            _exchangeAPI = ExchangeAPI.GetExchangeAPIAsync(ExchangeName.Coinbase).Result;
            _exchangeAPI.LoadAPIKeys(@"path\to\Keys.bin");

        }

        public async Task<IEnumerable<ExchangeMarket>> GetExchangeInfo()
        {
            return await _exchangeAPI.GetMarketSymbolsMetadataAsync();
        }

        public async Task<ExchangeOrderResult> Buy(ExchangeOrderRequest order)
        {
            return await _exchangeAPI.PlaceOrderAsync(order);
        }

        public async Task<ExchangeDepositDetails> GetDepositDetails(string coin)
        {
            return await _exchangeAPI.GetDepositAddressAsync(coin);
        }
    }
}
