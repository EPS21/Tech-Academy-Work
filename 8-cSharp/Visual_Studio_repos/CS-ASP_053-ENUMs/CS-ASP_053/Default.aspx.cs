using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_053
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Bob's Code
            /*
            var hero = new Character();
            hero.Name = "Elric";
            hero.Type = CharacterType.Fighter;

            // In some other part of your code ...
            if (hero.Type == CharacterType.Fighter)
            {
                resultLabel.Text = "Our hero is a fighter!";
            }
            */

            /*
            var hero = new Character();
            hero.Name = "super nerd";
            hero.Type = CharacterType.Mage; // using the enumeration CharacterType

            if (hero.Type == CharacterType.Mage)
            {
                resultLabel.Text = "Our hero is a mage!";
            }
            */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            var hero = new Character();
            hero.Name = heroNameTextBox.Text;

            CharacterType selection;
            if (Enum.TryParse(heroTypeDropDownList.SelectedValue , out selection))
            {
                hero.Type = selection;
            }

            if (hero.Type == CharacterType.Fighter)
            {
                resultLabel.Text = "You selected a fighter!";
            }
            */
            CharacterType selection;

            var hero = new Character();
            hero.Name = heroNameTextBox.Text;
            //hero.Type = Enum.TryParse(heroTypeDropDownList.SelectedValue, out selection);
            resultLabel.Text = "Our hero's name is " + hero.Name;

            
            if (Enum.TryParse(heroTypeDropDownList.SelectedValue , out selection))
            {
                resultLabel.Text += "<br/>Their class is: " + selection.ToString();
            }
            

            //Trying to mess with switch statement
            switch (heroTypeDropDownList.SelectedValue)
            {
                case "Swordsman":
                    resultLabel.Text += "<br/>Stats: 6Str, 4Dex, 3Agi";
                    break;
                case "Merchant":
                    resultLabel.Text += "<br/>Stats: 5Str, 5Dex, 3Agi";
                    break;
                case "Thief":
                    resultLabel.Text += "<br/>Stats: 4Str, 4Dex, 5Agi";
                    break;
                default:
                    break;
            }

        }

    public class Character
    {
        public string Name { get; set; }
        public CharacterType Type { get; set; }
    }

    public enum CharacterType
    {
        Swordsman,
        Merchant,
        Thief,        
    }


    }
}