<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="zen3displayPicture.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Display beach picture - by Eric Sheng<br />
            <br />
            <asp:Button ID="submitBtn" runat="server" OnClick="submitBtn_Click" Text="Submit" />
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/beach.jpg" Visible="False" />
            <br />
            <asp:Label ID="resultLabel" runat="server" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
