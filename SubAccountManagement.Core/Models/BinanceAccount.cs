using Binance.Net;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Authentication;
using SubAccountManagement.IO.Interfaces;
using SubAccountManagement.Core.Interfaces;

namespace SubAccountManagement.Core.Models
{
    public class BinanceAccount : IBinanceAccount
    {
        public BinanceAccount(IAccountSaveModel accountModel)
        {
            if(string.IsNullOrEmpty(accountModel.PrivateKey) || string.IsNullOrEmpty(accountModel.PublicKey))
            {
                throw new System.Exception("secret key or public key was null or empty");
            }

            Email = accountModel.Email;

            Client = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(accountModel.PublicKey, accountModel.PrivateKey),
                LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Warning
            });
        }

        public BinanceClient Client { get; set; }
        public string? Email { get; set; }
    }
}