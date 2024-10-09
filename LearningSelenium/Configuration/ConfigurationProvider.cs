using Microsoft.Extensions.Configuration;

namespace LearningSelenium.Configuration
{
    internal class ConfigurationProvider
    {
        private static ConfigurationManager configuration;

        public static ConfigurationManager Configuratrion
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationManager();
                    configuration.AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: false);
                }
                return configuration;
            }
        }
    }
}
