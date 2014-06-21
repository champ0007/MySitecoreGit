<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-toolbar.ascx.cs" Inherits="Training.BaseCore.Layouts.Site.Toolbar" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- TODO: Put in item, restrict access - deny anon web read access -->

<div id="slick">
    <sc:Text Field="Toolbar Content" ID="ToolbarContent" runat="server" />
</div>