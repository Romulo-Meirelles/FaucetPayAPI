using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FaucetPayLogs;
using FaucetPayPost;
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace Models
{
    internal partial class SendPayment
    {
        private partial class SendPaymentItems
        {
            public int status { get; set; }
            public string message { get; set; }
            public string rate_limit_remaining { get; set; }
            public string currency { get; set; }
            public string balance { get; set; }
            public string balance_bitcoin { get; set; }
            public string payout_id { get; set; }
            public string payout_user_hash { get; set; }
        }

        internal List<string> Send(string API, string Amount, string To_, bool Logs, string Currency = "BTC", bool Referral = false, string IPAddress = "")
        {
            List<string> SendRet = default;
            SendRet = null;
            string Request = null;

            string Calc;
            if (Amount.Contains(".") | Amount.Contains(","))
            {
                Calc = (Conversions.ToDouble(Amount.Replace(".", ",")) * 100000000d).ToString();
            }
            else
            {
                Calc = Amount;
            }

            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/v1/send";
                Request = Post.SEND(Site, "&api_key=" + API + "&amont=" + Calc.Replace(",", ".") + "&to=" + To_ + "&currency=" + Currency + "&referral=" + Referral.ToString() + "&ip_address=" + IPAddress, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                var Deserealized = JsonSerializer.Deserialize<SendPaymentItems>(Request);

                if (Deserealized.status != 200)
                {
                    SendRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                    }
                    return SendRet;
                }

                SendRet.Append(Deserealized.rate_limit_remaining);
                SendRet.Append(Deserealized.currency);
                SendRet.Append(Deserealized.balance);
                SendRet.Append(Deserealized.balance_bitcoin);
                SendRet.Append(Deserealized.payout_id);
                SendRet.Append(Deserealized.payout_user_hash);

                if (Logs == true)
                {
                    var LOG = new FLog();
                    LOG.Loggs("Rate Limit Remaining: " + Deserealized.rate_limit_remaining);
                    LOG.Loggs("Currency: " + Deserealized.currency);
                    LOG.Loggs("Balance: " + Deserealized.balance);
                    LOG.Loggs("Balance: " + Deserealized.balance);
                    LOG.Loggs("Balance Crypto: " + Deserealized.balance_bitcoin);
                    LOG.Loggs("Payout ID: " + Deserealized.payout_id);
                    LOG.Loggs("Payout User Hash: " + Deserealized.payout_user_hash);
                }
                return SendRet;
            }
            catch 
            {
                try
                {
                    var Deserealized = JsonSerializer.Deserialize<SendPaymentItems>(Request);

                    if (Deserealized.status != 200)
                    {
                        SendRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                        var LOG = new FLog();
                        if (Logs == true)
                        {
                            LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                        }
                        return SendRet;
                    }

                    SendRet.Append(Deserealized.message);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + Deserealized.message);
                    }
                    return SendRet;
                }
                catch (Exception exz)
                {
                    SendRet.Append(exz.Message);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + exz.Message);
                    }
                    return SendRet;
                }
            }

        }
    }
}