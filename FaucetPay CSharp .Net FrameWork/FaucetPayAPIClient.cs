using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Utilities;

namespace FaucetPayAPI
{
    public partial class FaucetPayAPIClient : IDisposable
    {
        private protected string MyAPI;

        public FaucetPayAPIClient(string API, bool Logs = true)
        {
            this.MyAPI = API;
        }
        public bool CheckAddressExist(string Address, string Currency = "BTC", bool Log = true)
        {
            var MyAddressExist = new CheckAddress();
            bool Response = MyAddressExist.CheckAddressExist(this.MyAPI, Address, Log, Currency);
            return Response;
        }
        public List<string> GetBalance(string Currency = "BTC", bool Log = true)
        {
            var MyGetBalance = new GetBalance();
            List<string> Response = MyGetBalance.Balance(this.MyAPI, Log, Currency);
            return Response;
        }
        public List<string> GetBalanceAll(bool Log = true)
        {
            var MyGetBalance = new GetBalance();
            List<string> Response = MyGetBalance.Balance(this.MyAPI, Log, "BTC", true);
            return Response;
        }
        public List<string> GetListCurrencies(bool Log = true)
        {
            var MyListCurrencies = new GetListOfCurrencies();
            List<string> Response = MyListCurrencies.GetListCurrencies(this.MyAPI, Log);
            return Response;
        }
        public List<string> GetListCurrenciesNames(bool Log = true)
        {
            var MyGetListCurrenciesNames = new GetListOfCurrencies();
            List<string> Response = MyGetListCurrenciesNames.GetListCurrenciesNames(this.MyAPI, Log);
            return Response;
        }
        public List<string> SendPay(string Amount, string To_, string Currency = "BTC", bool Referral = false, bool Log = true)
        {
            var MySendPayment = new SendPayment();
            List<string> Response = MySendPayment.Send(this.MyAPI, Amount, To_, Log, Currency, Referral);
            return Response;
        }
        public List<string> RecentPayout(string Currency = "BTC", string Count = "", bool Log = true)
        {
            var MyRecentPayout = new RecentPayouts();
            List<string> Response = MyRecentPayout.Payouts(this.MyAPI, Log, Currency, Count);
            return Response;
        }
        public async Task<Dictionary<string, string[]>> FaucetListAsync(bool Log = true)
        {
            var MyFaucetList = new FaucetList();
            Dictionary<string, string[]> Response = await MyFaucetList.ListAsync(Log, this.MyAPI);
            return Response;
        }
        public Dictionary<string, string[]> FaucetList(bool Log = true)
        {
            var MyFaucetList = new FaucetList();
            Dictionary<string, string[]> Response = MyFaucetList.List(Log, this.MyAPI);
            return Response;
        }
        public List<string> Donation(string Amount = "0.00000010", bool Log = true, Donation.Wallets Currency = 0, bool Referral = true, string IPAddrees = "")
        {
            var MyDonation = new Donation();
            List<string> Response = MyDonation.Donations(this.MyAPI, Amount, Log, Currency, Referral, IPAddrees);
            return Response;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~FaucetPayAPIClient()
        {
            Dispose();
        }
    }
}