<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-search-results.ascx.cs" Inherits=" Training.BaseCore.Layouts.Search.SearchResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="tc" Namespace=" Training.Controls.BaseCore" Assembly="Training.Controls" %>

<asp:Repeater ID="rpHolidays" runat="server">
    <ItemTemplate>
        <div class="sectionItem">
            <a href="<%# Sitecore.Links.LinkManager.GetItemUrl(Container.DataItem as Sitecore.Data.Items.Item) %>">
                <sc:FieldRenderer FieldName="Page Heading" Item="<%# Container.DataItem as Sitecore.Data.Items.Item %>" EnclosingTag="h2" runat="server" />
                <sc:Image Field="Summary Image" Item="<%# Container.DataItem as Sitecore.Data.Items.Item %>" runat="server" />
            </a>
            <sc:Text Field="Page Summary" Item="<%# Container.DataItem as Sitecore.Data.Items.Item %>" runat="server" />
            <a href="<%# Sitecore.Links.LinkManager.GetItemUrl(Container.DataItem as Sitecore.Data.Items.Item) %>" class="button bookButton">
                Find out more and book your place
            </a>
        </div>
    </ItemTemplate>
</asp:Repeater>

<tc:Paginator ID="pgPagination" runat="server" />