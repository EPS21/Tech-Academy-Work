using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_054
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string result = "";
            int switchExpression = 4;

            switch (switchExpression)
            {
                case 0:
                case 1:
                    result += "Case 0 or 1<br/>";
                    break;
                    return; // return takes you out of switch and also the method
                case 2:
                    result += "Case 2<br/>";
                    goto case 1;
                case 100 - 97:
                    result += "Case 3<br/>";
                    break;
                case 4:
                    result += "Case 4<br/>";
                    throw new Exception();
                default:
                    result += "Default<br/>";
                    break;
            }
            */

            // Using switch statements with Enumerations
            
            var hero = new Character();
            hero.Name = "Elric";
            hero.Type = CharacterType.Hunter;

            string result = "";
            switch (hero.Type)
            {
                case CharacterType.Knight:
                    result += "Knight";
                    break;
                case CharacterType.Wizard:
                    result += "Wizard";
                    break;
                case CharacterType.Priest:
                    result += "Priest";
                    break;
                case CharacterType.Hunter:
                    result += "Huntard";
                    break;
                case CharacterType.Blacksmith:
                    result += "Blacksmith";
                    break;
                case CharacterType.Assassin:
                    result += "Assassout";
                    break;
                default:
                    result += "No class selected";
                    break;
            }

            resultLabel.Text = result;

        }
    }

    public class Character
    {
        public string Name { get; set; }
        public CharacterType Type { get; set; }
    }

    public enum CharacterType
    {
        Knight,
        Wizard,
        Priest,
        Hunter,
        Blacksmith,
        Assassin        
    }

}