using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AutoBill.Utils
{
    abstract class Constants
    {
        public static readonly string CONNECTION_STRING = "Server=.\\SqlExpress1;Database=autobill;User Id=sa;Password=sa;";

        public static readonly string PES_2_PRICE = ConfigurationManager.AppSettings["pes2Price"];

        public static readonly string PES_3_PRICE = ConfigurationManager.AppSettings["pes3Price"];
    }
}
