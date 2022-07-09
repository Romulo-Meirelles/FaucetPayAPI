using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Models;
using Config;

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

    public partial class HttpClientRequester : RequesterBase, IDisposable
    {

        private readonly HttpClient _Client;
        private bool _DisposeClient;
        public HttpClientRequester(ApiConfig Configuration, HttpClient Client) : base(Configuration)
        {
            _Client = Client;
        }
       public override async Task<T> PostAsync<T>(string resource, Dictionary<string, string> parameters = null,bool noThrow = false)
        {
            if (resource == "faucetlist")
                        _Client.BaseAddress = new Uri(Configuration.BaseFaucetList);
            var result = await CreateRequestAsync(resource, HttpMethod.Post, parameters).ConfigureAwait(false);
            var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserialized = Deserialize<T>(response);
            HandleError(deserialized.Status, deserialized.Message, noThrow: noThrow);
            return deserialized;
        }

        public static void ConfigureClient(HttpClient Client, ApiConfig Configuration)
        {
            Client.BaseAddress = new Uri(Configuration.BaseUrl);
        }
        protected internal virtual Task<HttpResponseMessage> CreateRequestAsync(string Resource, HttpMethod Method, Dictionary<string, string> Parameters)
        {
            var content = new FormUrlEncodedContent(CreateParameterPairs(Parameters));
            return _Client.SendAsync(new HttpRequestMessage(Method, new Uri(Resource, UriKind.Relative)) { Content = content });
        }
        public static HttpClientRequester Create(ApiConfig Config, HttpClient Client = null, bool DisposeClient = false)
        {
            if (Client is null)
                DisposeClient = true;
            Client = Client ?? new HttpClient();
            ConfigureClient(Client, Config);
            return new HttpClientRequester(Config, Client) { _DisposeClient = DisposeClient };
        }
        public void Dispose()
        {
            if (_DisposeClient)
                _Client.Dispose();
        }
    }
}