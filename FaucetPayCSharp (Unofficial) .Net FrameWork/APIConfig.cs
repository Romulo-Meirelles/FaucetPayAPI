using System;
using System.Collections.Generic;
using Interceptors;

namespace Config
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
    public partial class ApiConfig
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; } = "https://faucetpay.io/api/v1/";
        public string BaseFaucetList { get; set; } = "https://faucetpay.io/api/listv1/";
        public IEnumerable<ISendInterceptor> SendInterceptors { get; set; } = Array.Empty<ISendInterceptor>();
        public void Check()
        {
            if (string.IsNullOrEmpty(ApiKey))
                throw new ArgumentException("The API key is missing.", nameof(ApiKey));
        }
    }
}