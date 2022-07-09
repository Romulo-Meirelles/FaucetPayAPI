using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace IPayClient
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
    public partial interface IFaucetPayClient : IDisposable
    {
        #region Async Method
        Task<BalanceResponse> GetBalanceAsync(string Currency);
        Task<CurrenciesResponse> GetCurrenciesAsync();
        Task<FaucetListResponse> FaucetListAsync();
        Task<bool> CheckAddressBooleanAsync(string Address, string Currency);
        Task<SendResponse> SendAsync(long SatoshiAmount, string To, string Currency, bool IsReferral = false);
        Task<IEnumerable<Payout>> GetPayoutsAsync(int TransactionCount, string Currency);
        Task<CheckAddressResponse> CheckAddressAsync(string Address, string Currency);
        #endregion

        #region Simple Method
        BalanceResponse GetBalance(string Currency);
        CurrenciesResponse GetCurrencies();
        FaucetListResponse FaucetList();
        bool CheckAddressBoolean(string Address, string Currency);
        SendResponse Send(long SatoshiAmount, string To, string Currency, bool IsReferral = false);
        IEnumerable<Payout> GetPayouts(int TransactionCount, string Currency);
        CheckAddressResponse CheckAddress(string Address, string Currency);
        #endregion
    }
}