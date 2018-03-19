<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_016.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Working with the Calendar Server Control<br />
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
        </asp:Calendar>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="getDateButton" runat="server" Text="Get Date" OnClick="getDateButton_Click" />
&nbsp;<asp:Button ID="setDateButton" runat="server" Text="Set Date" OnClick="setDateButton_Click" />
&nbsp;<asp:Button ID="showDateButton" runat="server" Text="Show Date" OnClick="showDateButton_Click" />
&nbsp;<asp:Button ID="selecedWeekButton" runat="server" Text="Selected Week" OnClick="selecedWeekButton_Click" />
&nbsp;<br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
