using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//File: SetGuessRange.aspx.cs
//Programmer: James Milne
//Description: This file contains the logic for validating what the user entered as their max and min numbers and storing them in the viewstate.

namespace A05
{
    public partial class SetGuessRange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Initialise all viewstate objects upon first load of the page
            if(IsPostBack == false)
            {
                ViewState["minIsGood"] = false;
                ViewState["maxIsGood"] = false;
                ViewState["minGuess"] = 0;
                ViewState["maxGuess"] = 0;

            }

            //Greet the user with their name entered from previous page
            if (PreviousPage !=null)
            {
                string name = (string)PreviousPageViewState["userName"];
                greeting.Text = "Hello, " + name + ", please choose your desired range";
                ViewState["userName"] = name;
            }

          if(IsPostBack == true)
            {
                //Determine if both numbers are valid, only if they both are then make a random number within the range

                bool minBool = (bool)ViewState["minIsGood"];
                bool maxBool = (bool)ViewState["maxIsGood"];

                if (minBool == true && maxBool == true)
                {
                    int minimum = (int)ViewState["minGuess"];
                    int maximum = (int)ViewState["maxGuess"];
                    ViewState["minimum"] = minimum;
                    ViewState["maximum"] = maximum;
                    makeRandomNumber(minimum, maximum);
                }
            }

        }

        //Method: submin_click()
        //Summary: When user clicks the submit button this method will do all the validation using the custom validator for the 
        // minimum number
     
        protected void SubMin_Click(object sender, ServerValidateEventArgs e)
        {
            object minGoodObj = ViewState["minIsGood"];
            bool minGood = (bool)minGoodObj;
            minGood = false;

            object minimumGuessObj = ViewState["minGuess"];
            int minimumGuess = (int)minimumGuessObj;
          
            //Try to convert the inputted value to a number, if tryparse returns false, then the user did not enter a number
            if(int.TryParse(e.Value, out minimumGuess) )
            {
                //Validate number is greater than 0
                if(minimumGuess >= 0 )
                {
                    e.IsValid = true;
                    minGood = true;
                    ViewState["minGuess"] = minimumGuess;
                  
                  

                }

               else
                {
                    e.IsValid = false;
                    
                    validateMin.Text = "Minimum number has to be greater than 0";
                }

            }
            else
            {
                e.IsValid = false;
                validateMin.Text = "Minimum guess is not a number!";
            }

            ViewState["minIsGood"] = minGood;

        }

        //Method: submax_click()
        //Summary: When user clicks the submit button this method will do all the validation using the custom validator for the 
        // maximum number
        protected void SubMax_Click(object sender, ServerValidateEventArgs e)
        {
            object maxGoodObj = ViewState["maxIsGood"];
            bool maxGood = (bool)maxGoodObj;
            maxGood = false;

            object maximumGuessObj = ViewState["maxGuess"];
            int maximumGuess = (int)maximumGuessObj;

            //Try to convert the inputted value to a number, if tryparse returns false, then the user did not enter a number
            if (int.TryParse(e.Value, out maximumGuess))
            {
                //Validate number is greater than 0
                if (maximumGuess >= 0)
                {
                    e.IsValid = true;
                    maxGood = true;
                    ViewState["maxGuess"] = maximumGuess;
                  

                }

                else
                {
                    e.IsValid = false;
                    validateMax.Text = "Maximum number has to be greater than 0";
                }

            }
            else
            {
                e.IsValid = false;
                validateMax.Text = "Maximum guess is not a number!";
            }

            ViewState["maxIsGood"] = maxGood;


        }

        //Method: makeRandomNumber()
        //Summary: This method creates a random number using the min and max values chosen by the user, 
        // and this method is only called if both numbers entered are valid
        protected void makeRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int number = rnd.Next(min, (max + 1));
            status.InnerHtml = "The number is " + number;
            ViewState["number"] = number;
            Server.Transfer("Guessing.aspx");
            
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


    }
}