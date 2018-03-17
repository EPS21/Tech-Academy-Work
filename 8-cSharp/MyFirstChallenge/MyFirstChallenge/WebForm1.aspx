<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MyFirstChallenge.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            How old are you?
            <asp:TextBox ID="ageBox" runat="server" Font-Bold="True"></asp:TextBox>
            <br />
            How much money do you have in your pocket?
            <asp:TextBox ID="moneyBox" runat="server" Font-Italic="True"></asp:TextBox>
            <br />
            <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Click Me To See Your Fortune" />
            <br />
            <asp:Label ID="Label" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>
    </form>
</body>
</html>
