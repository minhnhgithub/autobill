using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoBill.Model;

namespace AutoBill.Business
{
    interface IUserManager
    {
        void add(User user);

        bool isExistUser(String username);

        bool authenticate(User user);

        void changePassword(User exist, string newPassword);
    }
}
