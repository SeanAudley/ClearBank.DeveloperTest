using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;

namespace ClearBank.DeveloperTest.Factories
{
    public interface IAccountFactory
    {
        IAccountsData Start(IConfigService configurationService);
    }
}