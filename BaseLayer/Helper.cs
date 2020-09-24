using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer
{
    public sealed class Helper
    {
        private Helper()
        {
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["passportConString"].ConnectionString;
        }
    }
}
