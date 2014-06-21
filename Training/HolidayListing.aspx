<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayListing.aspx.cs" Inherits="Training.HolidayListing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Campaign Page</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <link href="Content/campaigns.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <sc:Sublayout ID="Sublayout1" Path="/Introduction.ascx" runat="server" />
        </div>
    </form>
</body>
</html>
