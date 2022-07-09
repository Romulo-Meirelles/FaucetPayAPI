using System.Collections.Generic;
using System.Threading.Tasks;
using Config;
using Models;

namespace Http
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
    public partial interface IRequester
    {
        ApiConfig Configuration { get; }
        Task<T> PostAsync<T>(string resource, Dictionary<string, string> parameters = null, bool noThrow = false) where T : FaucetPayResponse;
    }
}