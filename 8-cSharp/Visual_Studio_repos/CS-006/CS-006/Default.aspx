<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_006.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            color: #FF0000;
        }
        p {
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            background-color: #FFFF99;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Head Line 1</h1>
        <h2>Head Line 2</h2>
        <h3>Head Line 3</h3>
        <h4>Head Line 4</h4>
        <h5>Head Line 5</h5>
        <h6>Head Line 6</h6>
        <p>
            &nbsp;</p>
        <p class="auto-style1">
            This is some text I want to <span class="auto-style2">apply</span> a style to.</p>
        <p class="auto-style1">
            <a href="http://www.learnvisualstudio.net">Add a hyperlink.</a></p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="www.google.com" Target="_blank">This is another hyperlink</asp:HyperLink>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/16143362_1781176192206726_5438252790346119990_n.jpg" />
        <br />
        <br />
    </form>
    <table class="auto-style3">
        <tr>
            <td>Player</td>
            <td>Year</td>
            <td>Home Runs</td>
        </tr>
        <tr>
            <td>Sammy Sosa</td>
            <td>2005</td>
            <td>100</td>
        </tr>
        <tr>
            <td>Mark MacGuire</td>
            <td>2005</td>
            <td>102</td>
        </tr>
    </table>
    <ol>
        <li>First Item&nbsp;&nbsp; </li>
        <li>Second Item&nbsp;&nbsp; </li>
        <li>Third Item</li>
    </ol>
    <ul>
        <li class="auto-style4">Here is a thing</li>
        <li class="auto-style4">Here is another thing</li>
        <li class="auto-style4">And here is one more thing</li>
    </ul>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
