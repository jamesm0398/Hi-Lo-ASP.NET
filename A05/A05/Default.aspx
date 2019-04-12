<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="A05.Default" %>

<!DOCTYPE html>

<!--File: Default.aspx
    Programmer: James Milne
    Description: This file is the initial page of the Hi Lo game and asks the user for their name, and ensures they enter one.

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
    
       <p class="main">

           <!--Prompt user for their name -->
           <asp:Label ID="namePrompt" runat="server" Text="Hello, please enter your name: " ></asp:Label>
           <asp:TextBox  ID="nameBox" runat="server" Width ="200px"></asp:TextBox>
           <asp:Button ID="submitName" runat="server" Text="Submit" OnClick="submitName_Click" BackColor="#CCCCCC" ForeColor="#CC6600" Font-Bold="True" />

           <!-- Display an error if the user doesn't enter a name -->
           <asp:RequiredFieldValidator ID="nameBoxValidator" runat="server" BackColor="Red" BorderStyle="Outset" ControlToValidate="nameBox" 
            ErrorMessage="Please enter a name" Font-Names="Calibri" Height="20px" Width="200px" ForeColor="White"></asp:RequiredFieldValidator>
       </p>
  
    </form>
      </div>
</body>
</html>
