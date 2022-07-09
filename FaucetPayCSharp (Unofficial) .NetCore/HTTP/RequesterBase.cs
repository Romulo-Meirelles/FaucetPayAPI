using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Config;
using Exceptions;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


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
    public abstract partial class RequesterBase : IRequester
    {
        public RequesterBase(ApiConfig configuration)
        {
            Configuration = configuration;
            configuration.Check();
        }

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() } };

        protected virtual T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }
        protected virtual string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }

        protected IEnumerable<KeyValuePair<string, string>> CreateParameterPairs(IEnumerable<KeyValuePair<string, string>> source = null)
        {
            yield return new KeyValuePair<string, string>("api_key", Configuration.ApiKey);
            if (source is null)
                yield break;
            foreach (var item in source)
                yield return item;
        }
        public ApiConfig Configuration { get; private set; }

        public static void HandleError(int statusCode, string message, Exception innerException = null, bool noThrow = false)
        {
            if (noThrow)
                return;
            if (statusCode >= 200 && statusCode <= 299)
                return; // Success!
            throw new FaucetPayException(message, statusCode, innerException);
        }

        public abstract Task<T> PostAsync<T>(string resource, Dictionary<string, string> parameters = null, bool noThrow = false) where T : FaucetPayResponse;
    }
}