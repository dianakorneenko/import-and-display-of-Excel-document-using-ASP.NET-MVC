using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2WebApplication.Models
{
    public class GroupOfAccount
    {
        public int Id { get; set; }
        public int GroupOfAccountName { get; set; }
        public double SumOpeningBalanceActive { get; set; }
        public double SumOpeningBalancePassive { get; set; }
        public double SumTurnoverDebit { get; set; }
        public double SumTurnoverCredit { get; set; }
        public double SumOutgoingBalanceActive { get; set; }
        public double SumOutgoingBalancePassive { get; set; }

        public int? MyClassId { get; set; }
        public MyClass Class { get; set; }

        public List<Account> Accounts { get; set; }
        public GroupOfAccount()
        {
            Accounts = new List<Account>();
        }

    }
}