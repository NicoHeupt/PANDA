﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BankAccount
    {
        public int TraderID { get; }
        public Trader Trader { get; }

        public decimal Balance { get; private set; }
        public List<BankTransaction> BankTransactions { get; private set; }
    }
}
