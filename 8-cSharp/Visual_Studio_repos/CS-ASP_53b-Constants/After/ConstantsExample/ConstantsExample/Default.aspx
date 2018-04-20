<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConstantsExample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="okButton" runat="server" OnClick="oKButton_Click" Text="Ok" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
