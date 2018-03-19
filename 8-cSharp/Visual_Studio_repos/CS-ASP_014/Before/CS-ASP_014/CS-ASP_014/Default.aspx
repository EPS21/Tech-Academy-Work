<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_014.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Working with DateTime<br />
        <br />
        <asp:Button ID="refreshButton" runat="server" Text="Refresh" />
        <br />
        <br />
        using just ToString: <asp:Label ID="resultLabel1" runat="server"></asp:Label>
    
        <br />
        <br />
        ToLongDateString:
        <asp:Label ID="resultLabel2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        ToLongTimeString:
        <asp:Label ID="resultLabel3" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        ToShortDateString:
        <asp:Label ID="resultLabel4" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        AddDays(2).ToString():
        <asp:Label ID="resultLabel5" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        AddMonths(-2).ToString():
        <asp:Label ID="resultLabel6" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Month.ToString():
        <asp:Label ID="resultLabel7" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        IsDaylightSavingTime:
        <asp:Label ID="resultLabel8" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        DayOfWeek:
        <asp:Label ID="resultLabel9" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        DayOfYear:
        <asp:Label ID="resultLabel10" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Enter a date in mm/dd/yyyy format, and find out what day of the week this date was on:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="okButton" runat="server" AccessKey="x" OnClick="okButton_Click" Text="OK" />
        <br />
        <asp:Label ID="resultLabel0" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
