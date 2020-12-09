using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2WebApplication.Models
{
    public class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float SumOpeningBalanceActive { get; set; }
        public float SumOpeningBalancePassive { get; set; }
        public float SumTurnoverDebit { get; set; }
        public float SumTurnoverCredit { get; set; }
        public float SumOutgoingBalanceActive { get; set; }
        public float SumOutgoingBalancePassive { get; set; }
        public ICollection<GroupOfAccount> groupOfAccounts { get; set; }
        public MyClass()
        {
            groupOfAccounts = new List<GroupOfAccount>();
        }
       
    }
}