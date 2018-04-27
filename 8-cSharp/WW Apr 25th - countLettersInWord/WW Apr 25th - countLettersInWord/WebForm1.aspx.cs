using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WW_Apr_25th___countLettersInWord
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Write a program which, given any string, will output the # of vowels 
            // and the # of consonants in that string
        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            int vowelCounter = 0;
            int consonentCounter = 0;

            var str = inputTextBox.Text.ToLower().ToArray();
            var vowelArray = new char[] { 'a','e','i','o','u' };
            var consonentArray = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'x', 'z', 'w', 'y' }; 


            foreach (var letter in str)
            {
                //letter.ToString().ToLower();
                foreach (var vowel in vowelArray)
                {
                    if (letter == vowel)
                    vowelCounter++;
                }

                foreach (var consonent in consonentArray)
                {
                    if (letter == consonent)
                    consonentCounter++;
                }

            }

            resultLabel.Text = String.Format("There are {0} vowels and {1} consonents in the string {2}",
                vowelCounter,
                consonentCounter,
                inputTextBox.Text);

        }
    }
}