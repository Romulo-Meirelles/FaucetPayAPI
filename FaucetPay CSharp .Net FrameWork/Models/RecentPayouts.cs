using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using FaucetPayLogs;
using FaucetPayPost;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic

namespace Models
{
    internal partial class RecentPayouts
    {

        private partial class PayoutsItems
        {
            public int status { get; set; }
            public string message { get; set; }
            public RewardsSubItems[] rewards { get; set; }

            public partial class RewardsSubItems
            {
                [JsonPropertyName("to")]
                public string _to { get; set; }
                [JsonPropertyName("amount")]
                public string amount { get; set; }
                [JsonPropertyName("date")]
                public string _date { get; set; }
            }
        }

        internal List<string> Payouts(string API, bool Logs, string Currency = "BTC", string Count = "")
        {
            List<string> PayoutsRet = default;
            PayoutsRet = null;
            string Request = null;
            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/v1/payouts";
                Request = Post.SEND(Site, "&api_key=" + API + "&currency=" + Currency + "&count=" + Count, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                var Deserealized = JsonSerializer.Deserialize<PayoutsItems>(Request);

                if (Deserealized.status != 200)
                {
                    PayoutsRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                    }
                    return PayoutsRet;
                }

                for (int I = 0, loopTo = Deserealized.rewards.Count - 1; I <= loopTo; I++)
                {
                    PayoutsRet.Append(Deserealized.rewards(I)._to);
                    PayoutsRet.Append(Deserealized.rewards(I).amount);
                    PayoutsRet.Append(Deserealized.rewards(I)._date);

                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("To: " + Deserealized.rewards(I)._to);
                        LOG.Loggs("Amount: " + Deserealized.rewards(I).amount);
                        LOG.Loggs("Date: " + Deserealized.rewards(I)._date + Constants.vbCrLf);
                    }
                }

                return PayoutsRet;
            }
            catch 
            {

                try
                {
                    var Deserealized = JsonSerializer.Deserialize<PayoutsItems>(Request);

                    if (Deserealized.status != 200)
                    {
                        PayoutsRet.Add("Error: " + Deserealized.status + " " + Deserealized.message);
                        var LOG = new FLog();
                        if (Logs == true)
                        {
                            LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                        }
                        return PayoutsRet;
                    }

                    PayoutsRet.Append(Deserealized.message);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + Deserealized.message);
                    }
                    return PayoutsRet;
                }
                catch (Exception exz)
                {
                    PayoutsRet.Append(exz.Message);
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Error Message: " + exz.Message);
                    }
                    return PayoutsRet;
                }
            }

        }
    }
}