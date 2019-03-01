using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.PaymentSchemeValidation
{
    
    public class Chaps : IPaymentSchemeValidation
    {
        public bool Retrieve(PaymentScheme paymentScheme)
        {
            return paymentScheme == PaymentScheme.Chaps;
        }

        public MakePaymentResult Validate(Account account, decimal amount)
        {
            if (account == null ||
                account.Status != AccountStatus.Live ||
                !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) 
                )
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
