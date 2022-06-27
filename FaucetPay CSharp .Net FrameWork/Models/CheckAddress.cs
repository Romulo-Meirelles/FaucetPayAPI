using System;
using System.Text.Json;
using FaucetPayLogs;
using FaucetPayPost;

namespace Models
{
    internal partial class CheckAddress
    {

        private partial class CheckAddressItems
        {
            public int status { get; set; }
            public string message { get; set; }
            public string payout_user_hash { get; set; }
        }

        internal string CheckHashPayout(string API, string Address, bool Logs, string Currency = "BTC")
        {
            string Request = null;
            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/v1/checkaddress";
                Request = Post.SEND(Site, "&api_key=" + API + "&address=" + Address + "&currency=" + Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                var Deserealized = JsonSerializer.Deserialize<CheckAddressItems>(Request);

                if (Deserealized.status != 200)
                {
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Error: " + Deserealized.status + " " + Deserealized.message);
                    }
                    return "Error: " + Deserealized.status + " " + Deserealized.message;
                }

                if (Logs == true)
                {
                    var LOG = new FLog();
                    LOG.Loggs("Payout User Hash: " + Deserealized.payout_user_hash);
                }
                return Deserealized.payout_user_hash;
            }

            catch 
            {
                var Deserealized = JsonSerializer.Deserialize<CheckAddressItems>(Request);
                return Deserealized.message;
            }
        }

        internal bool CheckAddressExist(string API, string Address, bool Logs, string Currency = "BTC")
        {
            string Request = null;
            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/v1/checkaddress";
                Request = Post.SEND(Site, "&api_key=" + API + "&address=" + Address + "&currency=" + Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                var Deserealized = JsonSerializer.Deserialize<CheckAddressItems>(Request);


                if (Deserealized.status != 200)
                {
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Ckeck Address Exist: " + Address + " is False");
                    }
                    return false;
                }
                else
                {
                    if (Logs == true)
                    {
                        var LOG = new FLog();
                        LOG.Loggs("Ckeck Address Exist: " + Address + " is True");
                    }
                    return true;
                }
            }

            catch 
            {
                return false;
            }
        }
    }
}