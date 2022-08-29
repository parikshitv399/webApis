<%@ Page Language="C#" MasterPageFile="~/Error.Master" AutoEventWireup="true" CodeBehind="GenericException.aspx.cs" Inherits="WebFormsApp.WebForm1" %>

<asp:Content runat="server" ContentPlaceHolderID ="ErrorID">
    <h3>Something went wrong...</h3>
    <hr />
    <h5>Your ticket ID for further reference is <%= Guid.NewGuid() %></h5>
    <b>Please contact support at <a href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ>"</a>parikshitverma@kpmg.com</b>
</a>
</asp:Content>