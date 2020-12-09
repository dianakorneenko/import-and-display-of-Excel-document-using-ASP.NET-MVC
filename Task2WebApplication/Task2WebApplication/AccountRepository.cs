using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2WebApplication.Concrete;
using Task2WebApplication.Models;

namespace Task2WebApplication
{
    public class AccountRepository
    {
        private readonly List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public List<Account> GetAccounts()
        {
            var result = new List<Account>();
            using (MyDbContext db = new MyDbContext())
            {
                result = db.Accounts.ToList();
            }
            return result;
        }

        //public Account GetAccount(int id)
        //{
        //    Account result = null;
        //    using(MyDbContext db = new MyDbContext())
        //    {
        //        result =db.Accounts.FirstOrDefault(f => f.Id == id);
        //    }
        //    return result;
        //}
    }
}