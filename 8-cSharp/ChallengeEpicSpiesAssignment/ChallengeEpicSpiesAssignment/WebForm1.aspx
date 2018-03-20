<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ChallengeEpicSpiesAssignment.WebForm1" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 153px;
            height: 190px;
        }
        .auto-style2 {
            font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <img class="auto-style1" src="epic-spies-logo.jpg" /></p>
            <h1><span class="auto-style2">Spy New Assignment Form</span></h1>
            <p>
              Spy Code Name:
                <asp:TextBox ID="spyNameBox" runat="server"></asp:TextBox>
            </p>
            <p>
                New Assignment Name:
                <asp:TextBox ID="assignmentNameBox" runat="server"></asp:TextBox>
            </p>
            <p>
                End Date of Previous Assignment:<asp:Calendar ID="previousCalender" runat="server"></asp:Calendar>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                Start Date of New Assignment:<asp:Calendar ID="startDateCalender" runat="server"></asp:Calendar>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                Projected End Date of New Assignment:<asp:Calendar ID="endDateCalendar" runat="server"></asp:Calendar>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                &nbsp;</p>
            <p>
                <asp:Button ID="assignSpyButton" runat="server" OnClick="assignSpyButton_Click" Text="Assign Spy" />
            </p>
            <p>
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
