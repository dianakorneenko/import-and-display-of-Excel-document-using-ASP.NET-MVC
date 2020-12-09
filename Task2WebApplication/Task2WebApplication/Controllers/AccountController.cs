using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public AccountController( AccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Account
        public ActionResult Index()
        {
            var accounts = _accountService.GetAccounts();
            return View(accounts);
        }
    }
}