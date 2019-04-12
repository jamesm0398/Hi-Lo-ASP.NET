using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//File: Guessing.aspx.cs
//Programmer: James Milne
//Description: This file handles the validation of the user's guess and how close it was to the correct number

namespace A05
{
    public partial class Guessing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Initialise all viewstate objects upon first load of the page
            if (IsPostBack == false)
            {
                ViewState["guess"] = 0;
                ViewState["Number"] = 0;
                ViewState["minVal"] = 0;
                ViewState["maxVal"] = 0;
            }

            //Prompt the user for a guess, and store important values in the viewstate for later use
            if (PreviousPage != null)
            {
               int num = (int)PreviousPageViewState["number"]; 
               int minVal = (int)PreviousPageViewState["minGuess"];
               int maxVal = (int)PreviousPageViewState["maxGuess"];
                string name = (string)PreviousPageViewState["userName"];
                guessPrompt.Text = "Guess a number between " + minVal + " and " + maxVal;
                ViewState["Number"] = num;
                ViewState["minVal"] = minVal;
                ViewState["maxVal"] = maxVal;
                ViewState["userName"] = name;


            }
        }

      
        //Method: checkGuess_serverValidate()
        //Summary: Validate that the user entered a valid guess (not a letter or less than 0) and also
        // determine if it was the correct guess
        protected void checkGuess_ServerValidate(object source, ServerValidateEventArgs args)
        {
            object guessObj = ViewState["guess"];
            object numObj = ViewState["Number"];
            object minObj = ViewState["minVal"];
            object maxObj = ViewState["maxVal"];
            int guess = (int)guessObj;
            guess = 0;
            int num = (int)numObj;
            int minVal = (int)minObj;
            int maxVal = (int)maxObj;




            //Try to convert the inputted value to a number, if tryparse returns false, then the user did not enter a number
            if (int.TryParse(args.Value, out guess))
            {
                
                if(guess >= 0)
                {
                    args.IsValid = true;

                    if(guess > num)
                    {
                        status.InnerHtml = "You guessed too high, guess between " + minVal + " and " + guess; 
                    }

                    if(guess < num)
                    {
                        status.InnerHtml = "You guessed too low, guess between " + guess + " and " + maxVal;
                    }

                    if(guess == num)
                    {
                        status.InnerHtml = "";
                        won.InnerHtml = "You guessed the correct number";
                        playAgain.Visible = true;
                    }
                }

                else
                {
                    args.IsValid = false;
                    checkGuess.Text = "Guess has to be greater than 0";
                }
            }

            else
            {
                args.IsValid = false;
                checkGuess.Text = "That is not a number";
            }

            ViewState["guess"] = guess;
        }

        public StateBag ReturnViewState()
        {
            return ViewState;
        }

        //Method used to retreive information from the previous page's viewstate
        //This method was retrieved from the MyFirstWebApp example, and stackoverflow
        private StateBag PreviousPageViewState
        {
            get
            {
                StateBag returnValue = null;
                if (Page.PreviousPage != null)
                {
                    Object objPreviousPage = (Object)PreviousPage;
                    MethodInfo objMethod = objPreviousPage.GetType().GetMethod("ReturnViewState");
                    return (StateBag)objMethod.Invoke(objPreviousPage, null);
                }
                return returnValue;
            }
        }

        //Method: playAgain_Click()
        //Summary: If user presses this button, they will be transferred back to the set guess range page
        protected void playAgain_Click(object sender, EventArgs e)
        {
            Server.Transfer("SetGuessRange.aspx");
        }
    }
}