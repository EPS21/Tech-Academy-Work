using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // creating the arrays        
        string[] assets;
        int[] elections;
        double[] subterfuge;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                assets = new string[0];
                elections = new int[0];
                subterfuge = new double[0];

                ViewState.Add("Assets", assets);
                ViewState.Add("Elections", elections);
                ViewState.Add("Subterfuge", subterfuge);
            }
        }

        protected void addAssetBtn_Click(object sender, EventArgs e)
        {
            // initializing the arrays from viewstate
            assets = (string[])ViewState["Assets"];
            elections = (int[])ViewState["Elections"];
            subterfuge = (double[])ViewState["Subterfuge"];

            // adds a new entry to the arrays each time button is clicked
            Array.Resize(ref assets, assets.Length + 1);
            Array.Resize(ref elections, elections.Length + 1);
            Array.Resize(ref subterfuge, subterfuge.Length + 1);

            // parses latest entries added in the array
            int newestItem = assets.GetUpperBound(0);
            //int newestItem2 = elections.GetUpperBound(0);
            //int newestItem3 = subterfuge.GetUpperBound(0);

            // getting the values into latest item from each of their respective boxes
            assets[newestItem] = (assetNameTextBox.Text);
            elections[newestItem] = int.Parse(electionsRiggedTextBox.Text);
            subterfuge[newestItem] = double.Parse(subterfugeTextBox.Text);

            // place back into each respective viewstate
            ViewState["Assets"] = assets;
            ViewState["Elections"] = elections;
            ViewState["Subterfuge"] = subterfuge;                                 

            // result
            resultLabel.Text = String.Format("Total Elections Rigged: {0}<br />Average Acts of Subterfuge per Asset: {1:N2}" +
                "<br />(Last Asset you Added: {2})",
                elections.Sum(),
                subterfuge.Average(),
                assets[newestItem]);

            // clear text boxes afterwards
            assetNameTextBox.Text = "";
            electionsRiggedTextBox.Text = "";
            subterfugeTextBox.Text = "";
            
            
        }

        
    }
}