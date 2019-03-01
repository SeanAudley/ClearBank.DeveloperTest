using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.Services
{
    class ConfigService: IConfigService
    {
        private string _dataStoreType;

        public ConfigService()
        {
            _dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
        }

        public string DataStoreType()
        {
            return _dataStoreType;
        }
        
    }
}
