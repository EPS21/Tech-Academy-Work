<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_019.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Loan Application Form<br />
        <br />
        Name:&nbsp;
        <asp:TextBox ID="nameTextBox" runat="server">Spongborb</asp:TextBox>
        <br />
        <br />
        Phone Number: <asp:TextBox ID="phoneTextBox" runat="server">1231231234</asp:TextBox>
        <br />
        <br />
        Social Security Number: <asp:TextBox ID="ssTextBox" runat="server">123121234</asp:TextBox>
        <br />
        <br />
        Loan Origination Date:<asp:Calendar ID="loanDateCalendar" runat="server" SelectedDate="03/19/2018 15:17:51" VisibleDate="2018-03-19"></asp:Calendar>
        <br />
        Salary:
        <asp:TextBox ID="salaryTextBox" runat="server">50000</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
