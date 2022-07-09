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
    public partial interface IInterceptor
    {
    }
    public partial interface ISendInterceptor : IInterceptor
    {
        Task<InterceptorResult> CheckSendRequestAsync(long satoshiAmount, string to, string currency, bool isReferral);
    }
}