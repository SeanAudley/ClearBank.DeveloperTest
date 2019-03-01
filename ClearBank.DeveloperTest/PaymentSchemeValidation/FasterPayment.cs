using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.PaymentSchemeValidation
{
    
    public class Faster : IPaymentSchemeValidation
    {
        public bool Retrieve(PaymentScheme paymentScheme)
        {
            return paymentScheme == PaymentScheme.FasterPayments;
        }

        public MakePaymentResult Validate(Account account, decimal amount)
        {
            if (account == null ||
                account.Status != AccountStatus.Live ||
                !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) || 
                account.Balance < amount)
            {
                return new MakePaymentResult { Success = false };
            }
            else
            {
                return new MakePaymentResult { Success = true };
            }
        }

    }
}
