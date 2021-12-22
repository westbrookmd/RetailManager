using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Helpers
{
    //using this since we aren't in .NET Core yet
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {

            // get the tax rate from the app settings. This could be replaced with a key vault in .NET Core
            // or a database could be used, but this is just as single value
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Decimal.TryParse(rateText, out decimal output);

            if (!isValidTaxRate)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }

            return output;
        }

    }
}
