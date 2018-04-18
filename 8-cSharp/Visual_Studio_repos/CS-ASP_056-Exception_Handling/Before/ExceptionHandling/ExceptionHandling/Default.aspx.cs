
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExceptionHandling.Domain;
using ExceptionHandling.Domain.Exceptions;

namespace ExceptionHandling
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            string result = "";

            try
            {
                // Calculate percentage of wins:
                decimal wins = decimal.Parse(gamesWonTextBox.Text);
                decimal total = decimal.Parse(totalGamesTextBox.Text);
                decimal winningPercentage = wins / total;

                result = string.Format("Winning Percentage: {0:P}",
                    winningPercentage);

                
                var monster = new Character() { Name = "Zerg", HitPoints = 0 };
                var hero = new Character() { Name = "Buzz", HitPoints = 5 };
                GameActions.Battle(hero, monster);
                result += string.Format("{0} attacked {1} leaving him with {2} hit points.",
                    hero.Name,
                    monster.Name,
                    monster.HitPoints);
                
            }

            catch (ArgumentOutOfRangeException ex)
            {
                result = "Either the attacker or the defender are already dead";
            }

            // format exception (bad input)
            catch (FormatException ex)
            {
                result = "Format exception";
            }

            // put more specific exceptions to be caught first            
            catch (DivideByZeroException ex)
            {
                result = "oh shi you divided by 0";
            }

            // The custom class exception
            catch (CharacterAlreadyDeadException ex)
            {
                result = "Problem: " + ex.CharacterName + " was already dead. Could not defend.";
            }

            // General exception
            catch (Exception ex)
            {
                result = "There was a problem: " + ex.Message;
                //throw;
            }
            finally
            {
                // Performs cleanup here. Probably won't need this
                // till we start working with external resources
                // like database connection, network connections,
                // file system manipulation, etc.
            }

            resultLabel.Text = result;

            
        }
    }
}