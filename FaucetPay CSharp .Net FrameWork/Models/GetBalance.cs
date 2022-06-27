using System;
using System.Collections.Generic;
using System.Text.Json;
using FaucetPayLogs;
using FaucetPayPost;
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace Models
{
    internal partial class GetBalance
    {
        private partial class BalanceItems
        {
            public int status { get; set; }
            public string message { get; set; }
            public string currency { get; set; }
            public string balance { get; set; }
            public string balance_bitcoin { get; set; }

        }

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
        internal List<string> Balance(string API, bool Logs, string Currency = "BTC", bool AllCurrencies = false)
        {
            List<string> BalanceRet = default;
            BalanceRet = new List<string>();
            string Request = null;
            var Post = new PostRequest();
            string Site;
            try
            {
                if (AllCurrencies == true)
                {

                    var ListOfCurrencies = new List<string>();
                    Site = "https://faucetpay.io/api/v1/currencies";
                    Request = Post.SEND(Site, "&api_key=" + API, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                    var DeserealizedCur = JsonSerializer.Deserialize<CurrenciesItems>(Request);

                    if (DeserealizedCur.status != 200)
                    {
                        BalanceRet.Add("Error: " + DeserealizedCur.status + " " + DeserealizedCur.message);
                        var LOG = new FLog();
                        if (Logs == true)
                        {
                            LOG.Loggs("Error: " + DeserealizedCur.status + " " + DeserealizedCur.message);
                        }
                        return BalanceRet;
                    }

                    Site = "https://faucetpay.io/api/v1/balance";
                    foreach (var Element in DeserealizedCur.currencies)
                    {
                        Request = Post.SEND(Site, "&api_key=" + API + "&currency=", PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                        var Deserealized = JsonSerializer.Deserialize<BalanceItems>(Request);

                        if (Deserealized.status != 200)
                        {
                            BalanceRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                            var LOG = new FLog();
                            if (Logs == true)
                            {
                                LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                            }
                            return BalanceRet;
                        }

                        BalanceRet.Add(Deserealized.currency);
                        BalanceRet.Add(Deserealized.balance);
                        BalanceRet.Add(Deserealized.balance_bitcoin);

                        if (Logs == true)
                        {
                            var LOG = new FLog();
                            LOG.Loggs("Currency: " + Deserealized.currency);
                            LOG.Loggs("Balance: " + Deserealized.balance);
                            LOG.Loggs("Balance Cripto: " + Deserealized.balance_bitcoin);
                        }
                    }

                    return BalanceRet;
                }
                else
                {
                    Site = "https://faucetpay.io/api/v1/balance";
                    Request = Post.SEND(Site, "&api_key=" + API + "&currency=" + Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                    var Deserealized = JsonSerializer.Deserialize<BalanceItems>(Request);

                    if (Deserealized.status != 200)
                    {
                        BalanceRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                        var LOG = new FLog();
                        if (Logs == true)
                        {
                            LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                        }
                        return BalanceRet;
                    }

                    BalanceRet.Add(Deserealized.currency);
                    BalanceRet.Add(Deserealized.balance);
                    BalanceRet.Add(Deserealized.balance_bitcoin);

                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Currency: " + Deserealized.currency);
                        LOG.Loggs("Balance: " + Deserealized.balance);
                        LOG.Loggs("Balance Cripto: " + Deserealized.balance_bitcoin);
                    }
                    return BalanceRet;
                }
            }
            catch 
            {
                try
                {
                    Site = "https://faucetpay.io/api/v1/getbalance";
                    Request = Post.SEND(Site, "&api_key=" + API + "&currency=" + Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                    var Deserealized = JsonSerializer.Deserialize<BalanceItems>(Request);

                    if (Deserealized.status != 200)
                    {
                        BalanceRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                        var LOG = new FLog();
                        if (Logs == true)
                        {
                            LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                        }
                        return BalanceRet;
                    }

                    BalanceRet.Add(Deserealized.currency);
                    BalanceRet.Add(Deserealized.balance);
                    BalanceRet.Add(Deserealized.balance_bitcoin);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Currency: " + Deserealized.currency);
                        LOG.Loggs("Balance: " + Deserealized.balance);
                        LOG.Loggs("Balance Cripto: " + Deserealized.balance_bitcoin);
                    }
                    return BalanceRet;
                }
                catch 
                {
                    try
                    {
                        var Deserealized = JsonSerializer.Deserialize<BalanceItems>(Request);

                        if (Deserealized.status != 200)
                        {
                            BalanceRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                            var LOG = new FLog();
                            if (Logs == true)
                            {
                                LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                            }
                            return BalanceRet;
                        }

                        BalanceRet.Add(Deserealized.message);
                        if (Logs == true)
                        {
                            var LOG = new FLog();
                            LOG.Loggs("Error Message: " + Deserealized.message);
                        }
                        return BalanceRet;
                    }
                    catch (Exception exz)
                    {
                        BalanceRet.Add(exz.Message);
                        if (Logs == true)
                        {
                            var LOG = new FLog();
                            LOG.Loggs("Error Message: " + exz.Message);
                        }
                        return BalanceRet;
                    }
                }
            }
        }
    }
}