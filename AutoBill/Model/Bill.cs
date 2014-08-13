using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoBill.Model
{
    class Bill
    {
        private GameType gametype;
        private int hands;

        private double totalPrice;

        public Bill(GameType gametype, int hands) {
            this.gametype = gametype;
            this.hands = hands;
        }

        public Bill(double totalPrice) {
            this.totalPrice = totalPrice;
        }

        public GameType getGameType() {
            return this.gametype;
        }

        public int getHands() {
            return this.hands;
        }

        public int getTotalPrice() {
            return (int)totalPrice;
        }
    }
}
