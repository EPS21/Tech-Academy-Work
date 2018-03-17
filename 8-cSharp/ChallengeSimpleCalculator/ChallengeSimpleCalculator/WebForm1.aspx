<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ChallengeSimpleCalculator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
            background-color: aquamarine;
        }
        body {
            background-color: antiquewhite;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Simple Calculator</h1>
            <p>
                <span class="auto-style1">First Value:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="100px">5</asp:TextBox>
            </p>
            <p>
                <span class="auto-style1">Second Value:</span>
                <asp:TextBox ID="TextBox2" runat="server" Width="100px">8</asp:TextBox>
            </p>
            <p>
                <asp:Button ID="plusButton" runat="server" OnClick="plusButton_Click" Text="+" />
&nbsp;<asp:Button ID="minusButton" runat="server" OnClick="minusButton_Click" Text="-" />
&nbsp;<asp:Button ID="multiplyButton" runat="server" OnClick="multiplyButton_Click" Text="*" />
&nbsp;<asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text="/" />
            </p>
            <p>
                <asp:Label ID="resultLabel" runat="server" BackColor="#3399FF" BorderColor="#0033CC" Font-Bold="True"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
