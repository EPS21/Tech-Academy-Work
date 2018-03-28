using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethods
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {      
        
        protected void postBackListener(object sender, EventArgs e)
        {
            if (!isGoodInput()) return;
            else printResult();
        }

        /*******************
         ***** Methods *****
         *******************/

        // calculate volume with width and height   
        private double calculateVolume()
        {
            double width = int.Parse(widthTextBox.Text);
            double height = double.Parse(heightTextBox.Text);
            double volume = width * width * height;
            return volume;
        }        

        // calculate volume with width, height and length 
        private double calculateVolume(double length=0)
        {
            double width = double.Parse(widthTextBox.Text);
            double height = double.Parse(heightTextBox.Text);            
            double volume = width * length * height;
            return volume;
        }

        // check for bad input
        private bool isGoodInput()
        {
            if (!double.TryParse(widthTextBox.Text.Trim(), out double result)) return false;
            if (!double.TryParse(heightTextBox.Text.Trim(), out double result1)) return false;
            if (!double.TryParse(lengthTextBox.Text.Trim(), out double result2)) lengthTextBox.Text = widthTextBox.Text;
            if (double.Parse(lengthTextBox.Text.Trim()) == 0) lengthTextBox.Text = widthTextBox.Text;
            return true;
        }
        
        // print out result
        private void printResult()
        {
            if (groundRadioButton.Checked)
                resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", (calculateVolume(double.Parse(lengthTextBox.Text) * 0.15)));
            else if (airRadioButton.Checked)
                resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", (calculateVolume(double.Parse(lengthTextBox.Text) * 0.25)));
            else if (nextDayRadioButton.Checked)
                resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", (calculateVolume(double.Parse(lengthTextBox.Text) * 0.45)));
        }
        
    }   
    
}