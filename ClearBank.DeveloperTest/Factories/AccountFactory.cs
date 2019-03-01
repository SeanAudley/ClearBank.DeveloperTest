using ClearBank.DeveloperTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using ClearBank.DeveloperTest.Services;

namespace ClearBank.DeveloperTest.Factories
{
    public class AccountFactory : IAccountFactory
    {
        private IConfigService _config;
        

        public AccountFactory(IConfigService configurationService)
        {
            _config = configurationService;
        }

        public IAccountsData Start(IConfigService configurationService)
        {

            IAccountsData DataStore;

            var dataStoreType = _config.DataStoreType();
            
            switch (dataStoreType.ToString())
            {
                case "Backup":
                {
                    DataStore = new BackupAccountDataStore();
                    break;
                }

                default:
                {
                    DataStore = new AccountDataStore();
                    break;
                }
            }

            return DataStore;
        }
    }
}
