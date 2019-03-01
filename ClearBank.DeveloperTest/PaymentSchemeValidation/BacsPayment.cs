using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.PaymentSchemeValidation
{
    public class Bacs : IPaymentSchemeValidation
    {
        public bool Retrieve(PaymentScheme paymentScheme)
        {
            return paymentScheme == PaymentScheme.Bacs;
        }

        public MakePaymentResult Validate(Account account, decimal amount)
        {
            if (account == null ||
                account.Status != AccountStatus.Live ||
                !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs) 
                )
            {
                return new MakePaymentResult { Success = false };
            }
            else
                return new MakePaymentResult { Success = true };
        }
    }
}
