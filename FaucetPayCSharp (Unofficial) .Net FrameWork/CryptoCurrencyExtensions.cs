using System;

namespace Extensions
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
    public static partial class CryptocurrencyExtensions
    {
        private const string InaccuracyMessage = "Using double to store coin values is not recommended. This can lead to eventual inaccuracies. Please use a decimal value instead.";

        public static long ToSatoshi(this decimal coinValue)
        {
            return (long)Math.Round(coinValue * 100000000m);
        }

        public static long ToSatoshi(this double coinValue)
        {
            return (long)Math.Round(coinValue * 100000000d);
        }

        public static decimal ToCoinValue(this long satoshiValue)
        {
            return satoshiValue / 100000000m;
        }
    }
}