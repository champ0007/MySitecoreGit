<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore-search-form.ascx.cs" Inherits=" Training.BaseCore.Layouts.Search.SearchForm" %>

<div class="searchForm">
    <asp:Label ID="lblSearchText" Text="Search term:" runat="server">
        <asp:TextBox ID="txtSearchText" runat="server" />
    </asp:Label>
    <div class="searchFormRow">
        <div class="searchFormColumn">
            <asp:Label ID="lblTerrain" Text="Terrain type:" runat="server">
                <asp:DropDownList ID="ddlTerrain" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </asp:Label>
        </div>
        <div class="searchFormColumn">
            <asp:Label ID="lblHoliday" Text="Holiday type:" runat="server">
                <asp:DropDownList ID="ddlHolidayType" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </asp:Label>
        </div>
    </div>
    <div class="searchFormRow">
        <asp:Button runat="server" ID="Search" OnClick="Search_Click" Text="Find my holiday" />
    </div>
</div>