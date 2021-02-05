using Binance.Net;

namespace SubAccountManagement.Core.Interfaces
{
    interface IBinanceAccount
    {
        public BinanceClient Client { get; set; }
        public string? Email { get; set; }
    }
}
