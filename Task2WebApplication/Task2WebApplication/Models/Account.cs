using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2WebApplication.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public double OpeningBalanceActive { get; set; }
        public double OpeningBalancePassive { get; set; }
        public double TurnoverDebit { get; set; }
        public double TurnoverCredit { get; set; }
        public double OutgoingBalanceActive { get; set; }
        public double OutgoingBalancePassive { get; set; }

        public int? GroupOfAccountId { get; set; }
        public GroupOfAccount GroupOfAccount { get; set; }

       
    }
}