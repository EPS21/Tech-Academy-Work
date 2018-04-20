

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LocalDbExample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:GridView ID="customersGridView" runat="server">
         </asp:GridView>

        <p>&nbsp;</p>

        Name: <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
         <br />
        Address: <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
         <br />
        City: <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
         <br />
        State: <asp:TextBox ID="stateTextBox" runat="server"></asp:TextBox>
         <br />
        Zip: <asp:TextBox ID="zipTextBox" runat="server"></asp:TextBox>
         <br />
        Notes: <asp:TextBox ID="notesTextBox" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="Button1" runat="server" OnClick="okButton_Click" OnDataBinding="okButton_Click" Text="Button" />
         <br />
         <br />
         <br />
         <br />


         <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
