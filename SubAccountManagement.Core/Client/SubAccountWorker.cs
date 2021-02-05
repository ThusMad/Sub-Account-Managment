using Binance.Net;
using Binance.Net.Objects.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubAccountManagement.Core.Client
{
    public sealed class SubAccountWorker
    {
        private static readonly SubAccountWorker instance = new SubAccountWorker();
        private BinanceClient _binanceClient;

        static SubAccountWorker()
        {
        }

        private SubAccountWorker()
        {
            _binanceClient = new BinanceClient(new BinanceClientOptions
            {
                LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Warning
            });
        }

        public async Task<bool> PingBinance(int timeout, CancellationToken cancellationToken)
        {
            var task = _binanceClient.PingAsync(cancellationToken);

            return await Task.WhenAny(task, Task.Delay(timeout)) == task && task.IsCompleted;
        }

        public static SubAccountWorker Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
