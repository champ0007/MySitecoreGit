<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Containers.HeaderContainer" Codebehind="basecore-container-header.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="exp" Namespace="Training.Utilities.Basecore.Experiments" Assembly="Training.Utilities" %>

<div class="wrapper" id="headerWrapper">
    <div class="container" id="headerContainer">
        <sc:Placeholder runat="server" Key="HeaderContainer" />
        <a href="/"><sc:Image ID="Logo" Field="Site Logo" CssClass="logo" runat="server" /></a>
        <sc:XslFile runat="server" Path="/xsl/BaseCore/basecore-navigation-main.xslt" />
    </div>
</div>