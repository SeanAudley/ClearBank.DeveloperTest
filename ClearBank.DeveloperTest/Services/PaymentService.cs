using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.PaymentSchemeValidation;
using ClearBank.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentSchemeService
    {
        private readonly IAccountsData _accountData;
        private readonly List<IPaymentSchemeValidation> _paymentProcessingSchemes;
        
            
        public PaymentService(IAccountsData accService)
        {
            _accountData = accService;

            // build our PaymentScheme processors
            _paymentProcessingSchemes = new List<IPaymentSchemeValidation> {new Faster(), new Bacs(),new Chaps()};

        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            // step 1. Retrieve the account record
            var account = _accountData.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult();

            //step 2. validate the account
            IPaymentSchemeValidation paymentProcessor = _paymentProcessingSchemes.Single(scheme => scheme.Retrieve(request.PaymentScheme));
            result = paymentProcessor.Validate(account, request.Amount);

            if (result.Success)
            {
                //step 4. Debit the account
                _accountData.DebitAccount(account, request.Amount);
                
                //step 5. update the account record
                _accountData.UpdateAccount(account);
            }

            return result;
        }
    }
}
