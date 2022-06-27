using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FaucetPayLogs;
using FaucetPayPost;

namespace Models
{
    internal partial class GetListOfCurrencies
    {
        private partial class CurrenciesItems
        {
            public int status { get; set; }
            public string message { get; set; }
            public string[] currencies { get; set; }
            public CurrenciesNames[] currencies_names { get; set; }

            public partial class CurrenciesNames
            {
                public string name { get; set; }
                public string acronym { get; set; }
            }
        }

        internal List<string> GetListCurrencies(string API, bool Logs)
        {
            List<string> GetListCurrenciesRet = default;
            string Request = null;
            GetListCurrenciesRet = null;
            try
            {

                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/v1/currencies";
                Request = Post.SEND(Site, "&api_key=" + API, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                var Deserealized = JsonSerializer.Deserialize<CurrenciesItems>(Request);

                if (Deserealized.status != 200)
                {
                    GetListCurrenciesRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                    }
                    return GetListCurrenciesRet;
                }

                for (int I = 0, loopTo = Deserealized.currencies.Count - 1; I <= loopTo; I++)
                {
                    GetListCurrenciesRet.Add(Deserealized.currencies(I));
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Currencies Supported: " + Deserealized.currencies(I));
                    }
                }

                return GetListCurrenciesRet;
            }
            catch 
            {
                try
                {
                    var Deserealized = JsonSerializer.Deserialize<CurrenciesItems>(Request);

                    if (Deserealized.status != 200)
                    {
                        GetListCurrenciesRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                        var LOG = new FLog();
                        if (Logs == true)
                        {
                            LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                        }
                        return GetListCurrenciesRet;
                    }

                    return GetListCurrenciesRet;
                }

                catch (Exception exz)
                {
                    GetListCurrenciesRet.Append(exz.Message);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + exz.Message);
                    }
                    return GetListCurrenciesRet;
                }
            }
        }

        internal List<string> GetListCurrenciesNames(string API, bool Logs)
        {
            List<string> GetListCurrenciesNamesRet = default;
            string Request = null;
            GetListCurrenciesNamesRet = null;

            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/v1/currencies";
                Request = Post.SEND(Site, "&api_key=" + API, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                var Deserealized = JsonSerializer.Deserialize<CurrenciesItems>(Request);

                for (int I = 0, loopTo = Deserealized.currencies_names.Count - 1; I <= loopTo; I++)
                {
                    GetListCurrenciesNamesRet.Add(Deserealized.currencies_names(I).name);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Currencies Names Supported: " + Deserealized.currencies(I));
                    }
                }
                return GetListCurrenciesNamesRet;
            }
            catch 
            {
                try
                {
                    var Deserealized = JsonSerializer.Deserialize<CurrenciesItems>(Request);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + Deserealized.message);
                    }
                    return (List<string>)GetListCurrenciesNamesRet.Append(Deserealized.message);
                }
                catch (Exception exz)
                {
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + exz.Message);
                    }
                    return (List<string>)GetListCurrenciesNamesRet.Append(exz.Message);
                }
            }
        }
    }
}