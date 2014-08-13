using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoBill.Utils;
using AutoBill.Model;
using AutoBill.Business;

namespace AutoBill
{
    public partial class BillForm : Form
    {
        private Checkoutable checker;

        private int id = -1;

        public BillForm()
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

            if (Program.isLoginSuccess)
            {
                InitializeComponent();

                checker = new CheckoutImpl();
            }
            else
            {
                this.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            resetErrorMessage();

            if (!isStarted())
            {
                start();
            }
            else 
            {
                stop();
            }
        }

        private void start() {
            try
            {
                startCheckout();

                startTimer();

                startCalculateMoney();

                changeStartButtonUI();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void changeStartButtonUI() {
            btnStart.Text = "Stop";
            btnStart.BackColor = Color.Red;
        }

        private void stop() {
            stopCheckout();

            stopTimer();

            resetAll();
        }

        private bool isStarted() {
            return id != -1;
        }

        private double totalPrice = 0;
        private void startCalculateMoney()
        {
            totalPrice = initFirstBlock5Minute();

            lblTotalPrice.Text = totalPrice.ToString();
        }

        private double initFirstBlock5Minute()
        {
            GameType gameType = getGameType();
            int price = gameType.getGameTypePrice();

            return price / 60 * 5;
        }

        private double increasePriceEachMinute()
        {
            GameType gameType = getGameType();
            int price = gameType.getGameTypePrice();

            return price / 60 * 1;
        }

        private void startTimer()
        {
            if (!(secTimer.Enabled || minTimer.Enabled))
            {
                secTimer.Enabled = minTimer.Enabled = true;
                return;
            }

            throw new Exception("Timer has started.");
        }

        private void stopTimer() {
            if (secTimer.Enabled && minTimer.Enabled)
            {
                secTimer.Enabled = minTimer.Enabled = false;
                return;
            }

            throw new Exception("Timer has stopped.");
        }


        private void startCheckout()
        {
            GameType gametype = getGameType();
            int hands = (int)numHands.Value;
            
            Bill bill = new Bill(gametype, hands);

            id = checker.start(bill);
        }

        private void stopCheckout()
        {
            Bill bill = new Bill(totalPrice);

            checker.stop(bill, id);
        }

        private void resetErrorMessage()
        {
            lblError.Text = "";
        }

        private GameType getGameType()
        {
            if (rdPes2.Checked) {
                return new GameType(2);
            }

            if (rdPes3.Checked) {
                return new GameType(3);
            }

            throw new Exception("GameType not selected.");
        }

        private int timerSec = 0;
        private int timerMin = 0;
        private int timerHour = 0;
        private void secTimer_Tick(object sender, EventArgs e)
        {
            timerSec++;
            txtSec.Text = timerSec.ToString();
            if (timerSec == 60)
            {
                timerSec = 0;
                timerMin++;
                if (timerMin == 60)
                {
                    timerMin = 0;
                    timerHour++;
                    txtHour.Text = timerHour.ToString();
                }
                txtMin.Text = timerMin.ToString();
            }
        }

        private int minTimerTickerValue = 0;
        private void minTimer_Tick(object sender, EventArgs e)
        {
            minTimerTickerValue++;
            if (minTimerTickerValue > 5)
            {
                totalPrice += increasePriceEachMinute();
                lblTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void resetAll() {
            timerSec = 0;
            timerMin = 0;
            timerHour = 0;

            minTimerTickerValue = 0;

            totalPrice = 0;

            id = -1;

            btnStart.BackColor = Color.Blue;
            btnStart.Text = "Start";

            txtSec.Text = "00";
            txtMin.Text = "00";
            txtHour.Text = "00";
            lblTotalPrice.Text = "";
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm user = new UsersForm();
            user.ShowDialog();
        }
        
    }
}
