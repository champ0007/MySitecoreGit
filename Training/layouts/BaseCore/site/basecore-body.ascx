<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-body.ascx.cs" Inherits="Training.BaseCore.Layouts.Site.Body" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<form method="post" runat="server" id="mainform">

    <sc:Placeholder runat="server" ID="phMain" Key="Main"/>                      

    <sc:Sublayout path="/layouts/Basecore/site/basecore-toolbar.ascx" runat="server" />

</form>
<!--[if lt IE 9]>
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js" /></script>
<![endif]-->