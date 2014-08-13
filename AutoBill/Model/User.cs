using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoBill.Model
{
    class User
    {
        private string username;
        private string password;

        public User(string username, string password) {
            this.username = username;
            this.password = password;
        }

        public string getUsername() {
            return this.username;
        }

        public string getPassword() {
            return this.password;
        }
    }
}
