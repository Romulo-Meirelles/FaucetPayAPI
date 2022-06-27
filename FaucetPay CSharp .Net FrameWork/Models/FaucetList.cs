using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FaucetPayLogs;
using FaucetPayPost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Models
{
    internal partial class FaucetList
    {
        private partial class FaucetItems
        {

            [JsonPropertyName("status")]
            public int status { get; set; }

            [JsonPropertyName("message")]
            public string message { get; set; }

            [JsonPropertyName("list_data")]
            public Dictionary<string, object> list_data { get; set; }
        }
        private partial class Items
        {

            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public int owner_id { get; set; }
            public string owner_name { get; set; }
            public string currency { get; set; }
            public int timer_in_minutes { get; set; }
            public int reward { get; set; }
            public int is_enabled { get; set; }
            public string creation_date { get; set; }
            public string category { get; set; }
            public string paid_today { get; set; }
            public int total_users_paid { get; set; }
            public string active_users { get; set; }
            public string balance { get; set; }
            public int health { get; set; }
        }

        internal async Task<Dictionary<string, string[]>> ListAsync(bool Logs, string API = "")
        {
            var MyList = new Dictionary<string, string[]>();
            string Request = null;
            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/listv1/faucetlist";
                Request = await Post.SENDASYNC(Site, "&api_key=" + API, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                // Dim Json As String = IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\listfaucets.json")

                var Deserealized = JsonConvert.DeserializeObject<object>(Request);
                               

                if (Deserealized("status") != "200")
                {
                    MyList.Add("Error: ", new[] { Deserealized("status").ToString + " " + Deserealized("message").ToString });
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Error: " + Deserealized("status").ToString + " " + Deserealized("message").ToString);
                    }
                    return MyList;
                }


                foreach (JProperty MyItem in Deserealized("list_data"))
                {
                    foreach (JProperty MyCurr in Deserealized("list_data")(MyItem.Name))
                    {
                        foreach (JProperty MyNumber in Deserealized("list_data")(MyItem.Name)(MyCurr.Name))
                        {
                            var Des = JsonConvert.DeserializeObject<Items>(Deserealized("list_data")(MyItem.Name)(MyCurr.Name)(MyNumber.Name).ToString);
                            MyList.Add(MyCurr.Name + "_" + MyNumber.Name, new[] { Des.id, Des.name, Des.url, Des.owner_id, Des.owner_name, Des.currency, Des.timer_in_minutes, Des.reward, Des.is_enabled, Des.creation_date, Des.category, Des.paid_today, Des.total_users_paid, Des.active_users, Des.balance, Des.health });
                        }
                    }
                }

                return MyList;
            }
            catch (Exception ex)
            {

                MyList.Add("Error: ", new[] { ex.Message.ToString() });
                var LOG = new FLog();
                if (Logs == true)
                {
                    LOG.Loggs("Error: " + ex.Message.ToString());
                }
                return MyList;
            }

        }

        internal Dictionary<string, string[]> List(bool Logs, string API = "")
        {
            var MyList = new Dictionary<string, string[]>();
            string Request = null;
            try
            {
                var Post = new PostRequest();
                string Site = "https://faucetpay.io/api/listv1/faucetlist";
                Request = Post.SEND(Site, "&api_key=" + API, PostRequest.Method.POST_, PostRequest.Secure.TLS12);
                // Request = IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\listfaucets.json")

                var Deserealized = JsonConvert.DeserializeObject<object>(Request);

                if (Deserealized("status").ToString != "200")
                {
                    MyList.Add("Error: ", new[] { Deserealized("status").ToString + " " + Deserealized("message").ToString });
                    var LOG = new FLog();
                    if (Logs == true)
                    {
                        LOG.Loggs("Error: " + Deserealized("status").ToString + " " + Deserealized("message").ToString);
                    }
                    return MyList;
                }


                foreach (JProperty MyItem in Deserealized("list_data"))
                {
                    foreach (JProperty MyCurr in Deserealized("list_data")(MyItem.Name))
                    {
                        foreach (JProperty MyNumber in Deserealized("list_data")(MyItem.Name)(MyCurr.Name))
                        {
                            var Des = JsonConvert.DeserializeObject<Items>(Deserealized("list_data")(MyItem.Name)(MyCurr.Name)(MyNumber.Name).ToString);
                            MyList.Add(MyCurr.Name + "_" + MyNumber.Name, new[] { Des.id, Des.name, Des.url, Des.owner_id, Des.owner_name, Des.currency, Des.timer_in_minutes, Des.reward, Des.is_enabled, Des.creation_date, Des.category, Des.paid_today, Des.total_users_paid, Des.active_users, Des.balance, Des.health });
                        }
                    }
                }

                return MyList;
            }
            catch (Exception ex)
            {

                MyList.Add("Error: ", new[] { ex.Message.ToString() });
                var LOG = new FLog();
                if (Logs == true)
                {
                    LOG.Loggs("Error: " + ex.Message.ToString());
                }
                return MyList;
            }

        }

    }
}