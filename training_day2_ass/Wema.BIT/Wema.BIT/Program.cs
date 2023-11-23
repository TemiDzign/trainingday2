using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Transactions;

namespace BIT.Wema.User
{
    public class User
    {
        public static void Main(string[] args)
        {
            List<Transaction> transaction = new List<Transaction>()
            {
                new Transaction() {Id =1,UserId=1, Amount=1233},
                new Transaction() {Id =2,UserId=2, Amount=1233},
                new Transaction() {Id =3,UserId=3, Amount=1233},
                new Transaction() {Id =4,UserId=4, Amount=1233},
                new Transaction() {Id =5,UserId=5, Amount=1233}
            };



            List<Users> users = new List<Users>()
            {
                new Users() {Id =1, FirstName="Aluh", LastName="Johnson", Email="johnson@email.com", Transaction=null},

                new Users() {Id =2, FirstName="Jim", LastName="Johnson", Email="johnson@email.com", Transaction=transaction.Where(x => x.UserId == 2).ToList()},

                new Users() {Id =3, FirstName="Mike", LastName="Johnson", Email="johnson@email.com", Transaction=transaction.Where(x => x.UserId == 3).ToList()},

                new Users() {Id =4, FirstName="Jide", LastName="Johnson", Email="johnson@email.com", Transaction=transaction.Where(x => x.UserId == 4).ToList()},

                new Users() {Id =5, FirstName="Tomi", LastName="Johnson", Email="johnson@email.com", Transaction=transaction.Where(x => x.UserId == 5).ToList()},
            };

            List<Account> accounts = new List<Account>()
            {
                new Account() {Id = 1, AccountNumber = "1234567890", BVN = "9876543210", AccountName = "Aluh Johnson", PhoneNumber = "1234567890"},
                new Account() {Id = 2, AccountNumber = "2345678901", BVN = "0876543219", AccountName = "Jim Johnson", PhoneNumber = "2345678901"},
                // Add more accounts as needed
            };

            var userPayments = users.Where(x => x.Id == 1);
            var u = new List<User>();




            var json = JsonConvert.SerializeObject(userPayments, Formatting.Indented);

            foreach (var user in userPayments)
            {
                if (user.FirstName == "Tomi" || user.LastName == "Johnson") Console.WriteLine("First Name : " + user.FirstName + " Last Name : " + user.LastName);

            }


        }
    }

    public class Users
    {

        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public List<Transaction> Transaction { set; get; }
    }

    public class Transaction
    {

        public int Id { set; get; }
        public int UserId { set; get; }
        public decimal Amount { set; get; }
        public User User { set; get; }
    }

    public class Account
    {
        public int Id { set; get; }
        public string AccountNumber { set; get; }
        public string BVN { set; get; }
        public string AccountName { set; get; }
        public string PhoneNumber { set; get; }
    }
}



