using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoBill.Model;

namespace AutoBill.Business
{
    interface Checkoutable
    {
        int start(Bill bill);

        void stop(Bill bill, int id);
    }
}
