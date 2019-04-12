using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//File: Default.aspx.cs
//Programmer: James Milne
//Description: This is the code-behind file for Default.aspx, it stores the user's name in the viewstate and 
// handles the transfer to the next page of the game.

namespace A05
{
    public partial class Default : System.Web.UI.Page
    {
        //On initial page load initialise the userName viewstate object and focus on the name input textbox
        protected void Page_Load(object sender, EventArgs e)
        {
            nameBox.Focus(); 
            ViewState["userName"] = nameBox.Text;
        }

        //Method: SubmitName_click()
        //If the user presses this button then they will be transferred to the next page, only if the name textbox is not blank
        protected void submitName_Click(object sender, EventArgs e)
        {
            if (nameBox.Text != "")
            {
                Server.Transfer("SetGuessRange.aspx");
            }
        }

        public StateBag ReturnViewState()
        {
            return ViewState;
        }

    }


}