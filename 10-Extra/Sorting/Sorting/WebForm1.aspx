<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Sorting.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter some numbers:<br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="30px">1</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="30px">2</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="30px">3</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="30px">4</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox5" runat="server" Width="30px">5</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox6" runat="server" Width="30px">9</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox7" runat="server" Width="30px">8</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox8" runat="server" Width="30px">-7</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox9" runat="server" Width="30px">6</asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox10" runat="server" Width="30px">0</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="mergeSortBtn" runat="server" OnClick="mergeSortBtn_Click" Text="MergeSort" Width="90px" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
