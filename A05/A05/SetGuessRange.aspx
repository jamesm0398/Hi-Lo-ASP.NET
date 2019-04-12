<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetGuessRange.aspx.cs" Inherits="A05.SetGuessRange" %>

<!DOCTYPE html>

<!--File: SetGuessRange.aspx
    Programmer: James Milne
    Description: This file contains the logic for the user entering their maximum and minimum guess numbers

    Known issues: - Bug: When user submits their numbers, they have to press the submit button twice before they are
    transfered to the next page. (guessing.aspx)

    -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Hi-Lo Game</title>
    <link href ="~/Styling.css" rel ="stylesheet" type="text/css" />
</head>
<body>
   
    <div class="page">
        <h3>The Hi-Lo Game in ASP.NET</h3>
        <form id="form1" runat="server">
            <p class="main2">
                <asp:Label ID="greeting" runat="server"></asp:Label><!--Prompts the user for their numbers by greeting them with the name they entered-->

            </p>
            <p class="main2">
                <!--Textboxes for the user to enter their desired max and min numbers-->
                <asp:TextBox ID="minNum" runat="server" Width="100px" Height="100px" Font-Size="Larger"></asp:TextBox>
                &nbsp
                <asp:TextBox ID="maxNum" runat="server" Width="100px" Height="100px" Font-Size ="Larger"></asp:TextBox>
            </p>
            <p class="main2">
                <!--Labels telling the user which textbox is for which number-->
                <asp:Label ID="min" runat="server" Text="Minimum Number" Width="100px" Font-Size ="Large"></asp:Label>
                &nbsp
                <asp:Label ID="max" runat="server" Text="Maximum Number" Width="100px" Font-Size ="Large"></asp:Label>
            </p>
            <div class="main3">
                <!-- Button for user to submit the numbers they entered-->
                <asp:Button ID="subNumbers" runat="server" 
                 Text="Submit" Width="100px" Height="50px" BackColor="#CCCCCC" 
                 ForeColor="#CC6600" Font-Bold="True" />

                <!--Custom validators to make sure the user entered a number that is more than 0-->
                <asp:CustomValidator runat="server" ID="validateMin" ControlToValidate="minNum" OnServerValidate="SubMin_Click"
                    ErrorMessage="Minimum guess is not a number!" BackColor="Red" BorderStyle="Inset" Font-Bold="True" ForeColor="White"
                    Height="20px" Width="400px" ></asp:CustomValidator>

                <asp:CustomValidator runat="server" ID="validateMax" ControlToValidate="maxNum" OnServerValidate="SubMax_Click"
                    ErrorMessage="Maximum guess is not a number!" BackColor="Red" BorderStyle="Inset" Font-Bold="True" ForeColor="White"
                    Height="20px" Width="400px" ></asp:CustomValidator>
            </div>
            <div class="main3">
                <!--Display an error message if the user didn't enter a valid number-->
                 <span id="status" runat="server" style="background-color: red; color: white; border-style: inset; font-weight:500; height:20px; width:400px"></span>
            </div>
           

        </form>
    </div>
   
</body>
</html>
