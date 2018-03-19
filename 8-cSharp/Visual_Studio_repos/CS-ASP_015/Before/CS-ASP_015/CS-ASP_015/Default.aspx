<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_015.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Working with spans of time (TimeSpan)<br />
        <br />
        Click OK to get your total age in years, days, hours, minutes, and seconds<br />
        <asp:Label ID="myAgeLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="OK" />
        <br />
        <br />
        <asp:Label ID="resultLabelYears" runat="server"></asp:Label>
    
        <br />
        <asp:Label ID="resultLabelDays" runat="server"></asp:Label>
        <br />
        <asp:Label ID="resultLabelHours" runat="server"></asp:Label>
        <br />
        <asp:Label ID="resultLabelMinutes" runat="server"></asp:Label>
        <br />
        <asp:Label ID="resultLabelSeconds" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
