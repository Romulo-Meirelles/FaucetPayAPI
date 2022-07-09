using System;
using System.Threading.Tasks;

namespace Interceptors
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
    public partial class LimitSendInterceptor : ISendInterceptor
    {

        public string Currency { get; private set; }
        public long SatoshiLimit { get; private set; }

        [Obsolete]
        public LimitSendInterceptor(string currency, long satoshiLimit)
        {
            Currency = currency ?? CSharpImpl.Throw<string>(new ArgumentNullException(nameof(currency)));
            SatoshiLimit = satoshiLimit;
        }
        public async Task<InterceptorResult> CheckSendRequestAsync(long satoshiAmount, string to, string currency, bool isReferral)
        {
            if (!Currency.Equals(currency, StringComparison.OrdinalIgnoreCase))
                return await Task.FromResult(InterceptorResult.Success());
            return await Task.FromResult(InterceptorResult.IfFailure(satoshiAmount > SatoshiLimit, () => $"The send value ({satoshiAmount} {currency} satoshi) is higher than limit ({SatoshiLimit} {currency} satoshi)."));
        }
        private partial class CSharpImpl
        {
            [Obsolete("Please refactor calling code to use normal throw statements")]
            public static T Throw<T>(Exception e)
            {
                throw e;
            }
        }
    }
}