<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="WebFormsApp.UserRegistration" %>

<asp:Content ContentPlaceHolderID ="MainContent" runat="server">
    <h1>In User Registration</h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <p>Enter Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        <asp:TextBox ID="txtName" runat="server" Width="217px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White" BorderColor="#FF3300" BorderStyle="Double" ControlToValidate="txtName" ErrorMessage="Name cannot be empty!" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Underline="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </p>
    <p>Enter Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="217px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" BorderColor="#FF3300" BorderStyle="Double" ControlToValidate="txtPassword" ErrorMessage="Password cannot be empty!" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Underline="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" BorderColor="#FF3300" BorderStyle="Double" ControlToValidate="txtPassword" ErrorMessage="Password is incorrect!" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Underline="True" ForeColor="#FF3300" ValueToCompare="nimda"></asp:CompareValidator>
    </p>
    <p>Gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : <asp:DropDownList ID="ddlGender" runat="server" Width="140px">
            <asp:ListItem Value="0">--Select--</asp:ListItem>
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
            <asp:ListItem>Transgender</asp:ListItem>
            <asp:ListItem>Prefer not to say</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Auto-Generate Username :
        <asp:CheckBox ID="Yes" runat="server" />
    </p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnRegister" runat="server" OnClick="Button1_Click" Text="Generate" />
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkBtn" runat="server" OnClick="lnkBtn_Click">View available users</asp:LinkButton>
    </p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lstUsers" runat="server" Visible="False" Width="233px"></asp:ListBox>
    </p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblStatus" runat="server" Font-Italic="True" Font-Names="Monotype Corsiva" Font-Overline="True" Font-Size="XX-Large" Font-Underline="True" ForeColor="#0033CC" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>
