using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AddressException;
using Config;
using Exceptions;
using Http;
using Interceptors;
using IPayClient;
using Models;
using Microsoft.VisualBasic.CompilerServices;

namespace FaucetPayClient
{
    /// <summary>
    /// *** MADE FOR GITHUB ***
    /// WRITTEN BY ROMULO MEIRELLES.
    /// UPWORK: https://www.upwork.com/freelancers/~01fcbc5039ac5766b4
    /// CONTACT WHATSAPP: https://wa.me/message/KWIS3BYO6K24N1
    /// CONTACT TELEGRAM: https://t.me/Romulo_Meirelles
    /// GITHUB: https://github.com/Romulo-Meirelles
    /// DISCORD: đąяķňέs§¢øďε#2786
    /// </summary>
    /// <remarks></remarks>
    public partial class FaucetPayClient : IFaucetPayClient
    {

        public const string Bitcoin = "BTC";
        public const string BitcoinCash = "BCH";
        public const string Binance_BEP20 = "BNB";
        public const string Ethereum = "ETH";
        public const string Litecoin = "LTC";
        public const string Dogecoin = "DOGE";
        public const string Dash = "DASH";
        public const string DigiByte = "DBG";
        public const string Feyorra = "FEY";
        public const string Solana = "SOL";
        public const string Tron = "TRX";
        public const string Tether_TRC20 = "USDT";
        public const string ZCash = "ZEC";

        private readonly IRequester _Requester;
        public FaucetPayClient(IRequester Requester)
        {
            _Requester = Requester;
        }

        public static FaucetPayClient Create(ApiConfig Config, HttpClient Client = null)
        {
            var Requester = HttpClientRequester.Create(Config, Client);
            return new FaucetPayClient(Requester);
        }

        #region  Async Method 
        public async Task<SendResponse> SendAsync(long SatoshiAmount, string To, string Currency, bool IsReferral = false) 
        {
            await _Requester.Configuration.SendInterceptors.ThrowInterceptorErrorsAsync(i => i.CheckSendRequestAsync(SatoshiAmount, To, Currency, IsReferral));
            return await _Requester.PostAsync<SendResponse>("send", new Dictionary<string, string>() { { "amount", SatoshiAmount.ToString() }, { "to", To }, { "currency", Currency }, { "referral", IsReferral ? "true" : "false" } }).ConfigureAwait(false);
        }
        public async Task<IEnumerable<Payout>> GetPayoutsAsync(int TransactionCount, string Currency)
        {
            if (TransactionCount < 0 || TransactionCount > 100)
                throw new ArgumentOutOfRangeException($"The transaction count is out of range (0-100), got {TransactionCount}.", nameof(TransactionCount));
            return (await _Requester.PostAsync<PayoutsResponse>("payouts", new Dictionary<string, string>() { { "currency", Currency }, { "count", TransactionCount.ToString() } }).ConfigureAwait(false)).Payouts;
        }

        public async Task<BalanceResponse> GetBalanceAsync(string Currency)
        {
            return await _Requester.PostAsync<BalanceResponse>("balance", new Dictionary<string, string>() { { "currency", Currency } }).ConfigureAwait(false);
        }

        public async Task<CurrenciesResponse> GetCurrenciesAsync()
        {
            return await _Requester.PostAsync<CurrenciesResponse>("currencies").ConfigureAwait(false);
        }

        public async Task<FaucetListResponse> FaucetListAsync()
        {
            return await _Requester.PostAsync<FaucetListResponse>("faucetlist").ConfigureAwait(false);
        }

        public async Task<bool> CheckAddressBooleanAsync(string Address, string Currency)
        {
            var result = await CheckAddressRequestAsync(Address, Currency, true).ConfigureAwait(false);
            if (result.Status != 200)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<CheckAddressResponse> CheckAddressAsync(string Address, string Currency)
        {
            try
            {
                return await CheckAddressRequestAsync(Address, Currency).ConfigureAwait(false);
            }
            catch (FaucetPayException e) when (e.HasError(FaucetPayError.InvalidAddress))
            {
                throw new InvalidCryptocurrencyAddressException(e.Message, e);
            }
        }

        private async Task<CheckAddressResponse> CheckAddressRequestAsync(string Address, string Currency, bool NoThrow = false)
        {
            return await _Requester.PostAsync<CheckAddressResponse>("checkaddress", new Dictionary<string, string>() { { "address", Address }, { "currency", Currency } }, NoThrow);
        }
        #endregion

        #region Simple Method 
        public SendResponse Send(long SatoshiAmount, string To, string Currency, bool IsReferral = false)
        {
            _Requester.Configuration.SendInterceptors.ThrowInterceptorErrorsAsync(i => i.CheckSendRequestAsync(SatoshiAmount, To, Currency, IsReferral)).Wait();
            return _Requester.PostAsync<SendResponse>("send", new Dictionary<string, string>() { { "amount", SatoshiAmount.ToString() }, { "to", To }, { "currency", Currency }, { "referral", IsReferral ? "true" : "false" } }).Result;
        }
        public IEnumerable<Payout> GetPayouts(int TransactionCount, string Currency)
        {
            if (TransactionCount < 0 || TransactionCount > 100)
                throw new ArgumentOutOfRangeException($"The transaction count is out of range (0-100), got {TransactionCount}.", nameof(TransactionCount));
            return _Requester.PostAsync<PayoutsResponse>("payouts", new Dictionary<string, string>() { { "currency", Currency }, { "count", TransactionCount.ToString() } }).Result.Payouts;
        }
        public BalanceResponse GetBalance(string Currency)
        {
            return _Requester.PostAsync<BalanceResponse>("balance", new Dictionary<string, string>() { { "currency", Currency } }).Result;
        }
        public CurrenciesResponse GetCurrencies()
        {
            return _Requester.PostAsync<CurrenciesResponse>("currencies").Result;
        }
        public FaucetListResponse FaucetList()
        {
            return _Requester.PostAsync<FaucetListResponse>("faucetlist").Result; 
        }

        public bool CheckAddressBoolean(string Address, string Currency)
        {
            var result = CheckAddressRequest(Address, Currency, true);
            if (result.Status != 200)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public CheckAddressResponse CheckAddress(string Address, string Currency)
        {
            try
            {
                return CheckAddressRequest(Address, Currency);
            }
            catch (FaucetPayException e) when (e.HasError(FaucetPayError.InvalidAddress))
            {
                throw new InvalidCryptocurrencyAddressException(e.Message, e);
            }
        }

        private CheckAddressResponse CheckAddressRequest(string Address, string Currency, bool NoThrow = false)
        {
            return _Requester.PostAsync<CheckAddressResponse>("checkaddress", new Dictionary<string, string>() { { "address", Address }, { "currency", Currency } }, NoThrow).Result;
        }
        #endregion

        public void Dispose()
        {
            if (_Requester is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        private partial class Implements
        {
            public static T Assign<T>(ref T Target, T Value)
            {
                Target = Value;
                return Value;
            }
        }
    }
}