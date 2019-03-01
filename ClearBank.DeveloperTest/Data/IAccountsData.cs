using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.Data
{
    public interface IAccountsData
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);

        void DebitAccount(Account acc, decimal amount);

    }
}
