<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CasinoSlotMachine.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="160px" Width="164px" />
            <asp:Image ID="Image2" runat="server" Height="160px" Width="164px" />
            <asp:Image ID="Image3" runat="server" Height="160px" Width="164px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="pullButton" runat="server" OnClick="pullButton_Click" Text="Pull The Lever!" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - 2x Your Bet<br />
            2 Cherries - 3x Your Bet<br />
            3 Cherries - x4 Your Bet<br />
            <br />
            3 7&#39;s - Jackpot - 100x Your Bet<br />
            <br />
            HOWEVER ... if there&#39;s even one Bar you win nothing.</div>
    </form>
</body>
</html>
