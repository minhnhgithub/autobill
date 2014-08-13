using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoBill.Model
{
    class GameType
    {
        private int gameType;

        public GameType(int type) {
            this.gameType = type;
        }

        public int getGameType() {
            return this.gameType;
        }

        public int getGameTypePrice() {
            if (gameType == 2)
            {
                return Convert.ToInt32(Utils.Constants.PES_2_PRICE);
            }
            else if (gameType == 3) {
                return Convert.ToInt32(Utils.Constants.PES_3_PRICE);
            }

            throw new Exception("Invalid game type");
        }
    }
}
