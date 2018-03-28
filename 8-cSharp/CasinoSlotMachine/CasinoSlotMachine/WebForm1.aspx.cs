using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasinoSlotMachine
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //declare variables          
        
        //double playerBet;     

        // create array of names of respective images
        string[] images = new string[] { "Strawberry", "Bar", "Lemon", "Bell", "Clover", "Cherry",
            "Diamond", "Orange", "Seven", "HorseShoe", "Plum", "Watermelon" };

        // initialize the randomizer
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                // have some initial reel values on opening the page
                Image1.ImageUrl = spinReel();
                Image2.ImageUrl = spinReel();
                Image3.ImageUrl = spinReel();
                /*VS*/ ViewState.Add("PlayerMoney", 100);
                displayPlayerMoney();
            }            
        }        

        protected void pullButton_Click(object sender, EventArgs e)
        {
            /*VS*/ double playerMoney = double.Parse(ViewState["PlayerMoney"].ToString());
            double playerBet = double.Parse(betTextBox.Text);

            Image1.ImageUrl = spinReel();
            Image2.ImageUrl = spinReel();
            Image3.ImageUrl = spinReel();
            
            playerMoney -= playerBet;
            if (gotBar()) resultLabel.Text = String.Format("You got Bar, you lose your bet of {0:C}", playerBet);
            else if (gotOneCherry())
            {
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", playerBet, ((playerBet * 2)));
                playerMoney += (playerBet * 2);                
                //calcPayout(playerBet);
            }
            else if (gotTwoCherries())
            {
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", playerBet, ((playerBet * 3)));
                playerMoney += (playerBet * 3);
            }
            else if (gotThreeCherries())
            {
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", playerBet, ((playerBet * 4)));
                playerMoney += (playerBet * 4);
            }
            else if (gotJackpot())
            {
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", playerBet, ((playerBet * 100)));
                playerMoney += (playerBet * 100);
            }
            else resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", playerBet);
            
            /*VS*/ ViewState["PlayerMoney"] = playerMoney;
            displayPlayerMoney();            
        }

        /*****************
         * ** Methods ****
         * ***************/

        // get random image method to simulate spinning the reel
        private string spinReel()
        {
            // returns the url of the randomly obtained image
            return "/Images/" + images[random.Next(11)] + ".png";            
        }

        // displays current players money
        private void displayPlayerMoney()
        {
            moneyLabel.Text = String.Format("Player's Money: {0:C}", ViewState["PlayerMoney"]);
        }

        // calculate logic of multiplier for certain pull resuls                 
        private bool gotBar()
        {
            if (Image1.ImageUrl == "/Images/Bar.png" ||
                Image2.ImageUrl == "/Images/Bar.png" ||
                Image3.ImageUrl == "/Images/Bar.png")
            {
                return true;
            }
            else return false;
        }

        private bool gotOneCherry()
        {
            if ((Image1.ImageUrl == "/Images/Cherry.png" && Image2.ImageUrl != "/Images/Cherry.png" && Image3.ImageUrl != "/Images/Cherry.png") ||
                (Image1.ImageUrl != "/Images/Cherry.png" && Image2.ImageUrl == "/Images/Cherry.png" && Image3.ImageUrl != "/Images/Cherry.png") ||
                (Image1.ImageUrl != "/Images/Cherry.png" && Image2.ImageUrl != "/Images/Cherry.png" && Image3.ImageUrl == "/Images/Cherry.png"))
            {                
                return true;
            }            
            return false;
        }        

        private bool gotTwoCherries()
        {
            if ((Image1.ImageUrl == "/Images/Cherry.png" && Image2.ImageUrl == "/Images/Cherry.png" && Image3.ImageUrl != "/Images/Cherry.png") ||
                (Image1.ImageUrl == "/Images/Cherry.png" && Image2.ImageUrl != "/Images/Cherry.png" && Image3.ImageUrl == "/Images/Cherry.png") ||
                (Image1.ImageUrl != "/Images/Cherry.png" && Image2.ImageUrl == "/Images/Cherry.png" && Image3.ImageUrl == "/Images/Cherry.png"))
            {
                return true;
            }
            else return false;
        }

        private bool gotThreeCherries()
        {
            if (Image1.ImageUrl == "/Images/Cherry.png" && 
                Image2.ImageUrl == "/Images/Cherry.png" &&
                Image3.ImageUrl == "/Images/Cherry.png")
            {
                return true;
            }
            else return false;
        }

        private bool gotJackpot()
        {
            if (Image1.ImageUrl == "/Images/Seven.png" &&
                Image2.ImageUrl == "/Images/Seven.png" &&
                Image3.ImageUrl == "/Images/Seven.png")
            {
                return true;
            }
            else return false;
        }

        private int getMultiplier()
        {
            if (gotOneCherry()) return 2;
            else if (gotTwoCherries()) return 3;
            else if (gotThreeCherries()) return 4;
            else if (gotJackpot()) return 100;
            else return 0;            
        }

        // tried to refactor my code more with this, but wasn't working
        private void calcPayout(double Bet)
        {
            double playerMoney = double.Parse(ViewState["PlayerMoney"].ToString());
            playerMoney += (Bet * 2);
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", Bet, (Bet * 2));
            ViewState["PlayerMoney"] = playerMoney;
        }

    }
}