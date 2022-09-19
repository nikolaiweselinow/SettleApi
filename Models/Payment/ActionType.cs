using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi.Models.Payment
{
    public class ActionType
    {
        public static string AUTH = "AUTH";
        public static string SALE = "SALE";
        public static string CAPTURE = "CAPTURE";
        public static string REFUND = "REFUND";
        public static string ABORT = "ABORT";
    }
}
