﻿<%@ Control Language="c#" AutoEventWireup="True" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Content.BookHoliday" Codebehind="basecore-book-holiday.ascx.cs" %>

<!-- This form *could* be created using Web Form For Marketers; it is capable of creating items of a certain template based on -->

<div class="formWrapper">
    <div class="formRow">
        <asp:Label ID="lblFirstName" AssociatedControlID="txtFirstName" runat="server"><%= Sitecore.Globalization.Translate.Text("LabelFirstName") %>:</asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server" />
    </div>
    <div class="formRow">
        <asp:Label ID="lblSurname" AssociatedControlID="txtSurname" runat="server"><%= Sitecore.Globalization.Translate.Text("LabelSurname") %>:</asp:Label>
        <asp:TextBox ID="txtSurname" runat="server" />
    </div>
    <div class="formRow">
        <asp:Label ID="lblHoliday" AssociatedControlID="ddlHoliday" runat="server"><%= Sitecore.Globalization.Translate.Text("LabelHoliday") %>:</asp:Label>
        <asp:DropDownList CssClass="ddlHolidays" ID="ddlHoliday" OnSelectedIndexChanged="ddlHoliday_SelectedIndexChanged" AutoPostBack="true" runat="server">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="formRow date">
        <asp:Label ID="lblDate" AssociatedControlID="ddlHolidayDate" runat="server"><%= Sitecore.Globalization.Translate.Text("LabelDate") %>:</asp:Label>
        <asp:DropDownList CssClass="ddlDate" ID="ddlHolidayDate" runat="server">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="formRow plain">
        <asp:Button ID="btnBook" Text="Book holiday" OnClick="btnBook_Click" runat="server" />
    </div>
</div>