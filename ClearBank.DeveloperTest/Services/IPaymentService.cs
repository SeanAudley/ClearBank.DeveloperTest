using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentSchemeService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
