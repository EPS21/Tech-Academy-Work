<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_053.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="heroNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:DropDownList ID="heroTypeDropDownList" runat="server">
            <asp:ListItem>Select one ...</asp:ListItem>
            <asp:ListItem>Swordsman</asp:ListItem>
            <asp:ListItem>Merchant</asp:ListItem>
            <asp:ListItem>Thief</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
