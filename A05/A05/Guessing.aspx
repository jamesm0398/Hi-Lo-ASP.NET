<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guessing.aspx.cs" Inherits="A05.Guessing" %>

<!DOCTYPE html>

<!--File: Guessing.aspx
    Programmer: James Milne
    Description: This file contains the logic for handling the user's guess for a randomly generated number created from the previous page
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
                <!--Ask the user for a guess-->
                <asp:Label ID="guessPrompt" runat="server"></asp:Label>
                <asp:TextBox ID="guess" runat="server" Width="100px" Height="100px" Font-Size="Larger"></asp:TextBox>
            </p>
            <div class="main3">
                <!--Button for the user to submit their guess-->
                 <asp:Button ID="subGuess" runat="server" 
                 Text="Submit" Width="100px" Height="50px" BackColor="#CCCCCC" 
                 ForeColor="#CC6600" Font-Bold="True" />

                <!-- Validate that the user entered a valid guess, i.e. not a letter-->
                <asp:CustomValidator runat="server" ID="checkGuess" ControlToValidate="guess" OnServerValidate="checkGuess_ServerValidate"
                    BackColor="Red" BorderStyle="Inset" Font-Bold="True" ForeColor="White"
                    Height="20px" Width="400px" ></asp:CustomValidator>
            </div>
            <div class="main3">
                <!--Button prompting the user to play again, only visible after the user wins-->
                <asp:Button ID="playAgain" runat="server" Text="Play again?" Visible="false"
                    Width="100px" Height="50px" BackColor="#CCCCCC" 
                 ForeColor="#CC6600" Font-Bold="True" OnClick="playAgain_Click"  />

                <!--Text that will tell the user they guessed correctly-->
                <span id ="won" runat="server" style="background-color: lawngreen; color: black; border-style: inset; font-weight:500; height:20px; width:400px"></span>
                 
                <!--Text that will tell the user they guessed incorrectly-->
                <span id="status" runat="server" style="background-color: red; color: white; border-style: inset; font-weight:500; height:20px; width:400px"></span>
            </div>
     
            
        </form>

    </div>
</body>
</html>
