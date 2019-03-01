using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.PaymentSchemeValidation
{
    interface IPaymentSchemeValidation
    {
        bool Retrieve(PaymentScheme paymentScheme);
        MakePaymentResult Validate(Account account, decimal amount);
    }
}
