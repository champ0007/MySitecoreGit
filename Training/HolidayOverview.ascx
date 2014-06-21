<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HolidayOverview.ascx.cs" Inherits="Training.HolidayOverview" %>
<!-- THIS IS THE HOLIDAY OVERVIEW SECTION -->
<div class="indentedSection">
	<table>
		<tr>
			<th>Date</th>
			<td><sc:Date Field="Start date" Runat="server" /></td>
		</tr>
		<tr>
			<th>Price per  person</th>
			<td><sc:Text Field="Price per person" Runat="server"/></td>
		</tr>					
	</table>
</div>			
<!-- END -->