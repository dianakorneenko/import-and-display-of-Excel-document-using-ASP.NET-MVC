using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2WebApplication.Models;

namespace Task2WebApplication
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        //public Account GetAccount(int id)
        //{
        //    return _accountRepository.GetAccount(id);
        //}
    }
}