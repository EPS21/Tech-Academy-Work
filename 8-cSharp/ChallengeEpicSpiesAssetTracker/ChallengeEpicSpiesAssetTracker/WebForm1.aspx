<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ChallengeEpicSpiesAssetTracker.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 150px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <img alt="" class="auto-style1" src="epic-spies-logo.jpg" /><br />
                <br />
                Asset Performance Tracker</h1>
            <p>
                Asset Name:
                <asp:TextBox ID="assetNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Elections Rigged:
                <asp:TextBox ID="electionsRiggedTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Acts of Subterfuge Performed:
                <asp:TextBox ID="subterfugeTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="addAssetBtn" runat="server" OnClick="addAssetBtn_Click" Text="Add Asset" />
            </p>
            <p>
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
