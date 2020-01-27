using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Design.Patterns.Structural
{
    public class Façade
    {

        public string GetDataInUrl(string url)
        {
            // some complex system
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return responseFromServer;
        }
    }


    // https://en.wikipedia.org/wiki/Law_of_Demeter
    // (Law of Demeter, LoD) or principle of "least knowledge" - this is a specific case architecture design - loose coupling.

    // - Each unit should have only limited knowledge about other units: only units "closely" related to the current unit.
    // - Each unit should only talk to its friends; don't talk to strangers.
    // - Only talk to your immediate friends.


    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private Wallet _wallet;

        public Customer(Wallet wallet)
        {
            _wallet = wallet;
        }

        public Wallet GetWallet() => _wallet;

        // best practice
        public int GetPayment(int payment)
        {
            if (_wallet != null)
            {
                if (_wallet.GetValue() >= payment)
                {
                    _wallet.SubsetMoney(payment);
                    return payment;
                }
            }
            throw new Exception("ex");
        }

    }

    class Wallet
    {
        private int _value;

        public int GetValue() 
            => _value;

        public int SetValue(int val) 
            => this._value = val;

        public int AddMoney(int money) 
            => this._value = money;

        public void SubsetMoney(int money)
        {
            if (_value > money)
                _value -= money;
            else
                throw new Exception("no many for pay");
        }
    }

    class PaperBoy
    {
        public void PayBadPractice(Customer customer)
        {
            int payment = 200;
            var wallet = customer.GetWallet();

            if (wallet.GetValue() > payment)
            {
                wallet.SubsetMoney(payment);
            }
            else
            {
                // ...
            }
        }

        public void PayBetterPractice(Customer customer)
        {
            // .. add method payment to customet - rules knowledge only one friend
            int payment = 200;
            var paid = customer.GetPayment(payment);
            if (paid == payment)
            {
                // operation completed
            }
        }

    }
}
