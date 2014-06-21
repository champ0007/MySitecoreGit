using System;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.Base;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Fields;
using Sitecore;
using System.Linq;
using Sitecore.Data;
using Sitecore.Layouts;
using Training.Utilities.Basecore.References;
using Sitecore.SecurityModel;
using System.Web.Services;
using System.Collections.Generic;
using Training.Utilities.BaseCore.References;
using System.Collections;
using System.Text.RegularExpressions;
using Training.Utilities.BaseCore.Holidays;
using Training.Utilities.BaseCore.Extensions;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Training.Utilities.BaseCore.Membership;
using Sitecore.Security.Accounts;

namespace Training.BaseCore.Layouts.Content {

    /// <summary>
    /// 
    /// </summary>
    public partial class BookHoliday : BaseSublayout
    {
        private readonly string fnThankYouPage = "Thank You Page";
        private readonly string dbMaster = "master";
        private readonly string fnPageTitle = "Page Title";
        private readonly string fnPageHeading = "Page Heading";
        private readonly string fnBookedDate = "Booked Date";
        private readonly string fnFirstName = "First Name";
        private readonly string fnSurname = "Surname";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDowns();

                if (!Request.QueryString.HasKeys())
                    return;

                Date = Request.QueryString[Keys.DateID];

                Item holidayDate = Sitecore.Context.Database.GetItem(new ID(Date));

                if (holidayDate != null)
                {
                    string holidayID = holidayDate.Axes.GetAncestors().Where(x => x.TemplateID == TemplateReferences.Holiday).Select(x => x.ID).FirstOrDefault().ToString();
                    ddlHoliday.SelectedValue = holidayID;

                    Item holiday = Sitecore.Context.Database.GetItem(new ID(new Guid(holidayID)));

                    PopulatDateDropDown(holiday);
                    ddlHolidayDate.SelectedValue = Date;
                }
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindDropDowns()
        {
            Item holidayRoot = ItemReferences.HolidaysRoot;

            foreach (Item holiday in holidayRoot.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.Holiday).ToList())
            {
                ddlHoliday.Items.Add(new System.Web.UI.WebControls.ListItem(FieldRenderer.Render(holiday, fnPageTitle), holiday.ID.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBook_Click(object sender, EventArgs e)
        {
            if (ItemReferences.SiteRoot != null)
            {
                // Equivalent to Sitecore.Configuration.Factory.GetDatabase("master");
                Database master = Sitecore.Data.Database.GetDatabase(dbMaster);
                
                Item bookingsRoot = master.GetItem(ItemReferences.BookingsRoot.ID);

                if (bookingsRoot != null)
                {
                    try
                    {
                        // Rather than using the SecurityDisabler(), set up a user whose job is to create bookings, and use the UserSwitcher() to 
                        // run the code with their security privileges.

                        using (new SecurityDisabler())
                        {
                            string name = Regex.Replace(txtFirstName.Text + txtSurname.Text, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled).ToLower();

                            Guid dateGuid;
                            if (Guid.TryParse(ddlHolidayDate.SelectedValue, out dateGuid))
                            {
                                // create new booking
                                Booking booking = new Booking();

                                booking.BookingItemName = Encoder.XmlEncode(name + DateUtil.IsoNow);
                                booking.FirstName = Encoder.HtmlEncode(txtFirstName.Text);
                                booking.Surname = Encoder.HtmlEncode(txtSurname.Text);
                                booking.HolidayDate = dateGuid;

                                // create an item under the bookings root

                                Item bookingItem = bookingsRoot.Add(booking.BookingItemName, TemplateReferences.Booking);

                                // populate the item with values from the transient booking item

                                bookingItem.Editing.BeginEdit();
                                bookingItem.Fields[fnFirstName].Value = booking.FirstName;
                                bookingItem.Fields[fnSurname].Value = booking.Surname;
                                bookingItem.Fields[fnBookedDate].Value = booking.HolidayDate.ToString();
                                bookingItem.Editing.EndEdit();
                            }
                        }

                        // get URL for thank-you page - specified in Sitecore - and redirect

                        ReferenceField redirect = Sitecore.Context.Item.Fields[fnThankYouPage];

                        if (redirect.TargetItem != null)
                        {
                            Response.Redirect(Sitecore.Links.LinkManager.GetItemUrl(redirect.TargetItem), false);
                        }
                    }
                    catch
                    {
                        Sitecore.Diagnostics.Log.Fatal(MessageReferences.CodeMessageCannotProcessBooking, this);

                        // TODO: Error handling
                    }
                }
            }
        }

        /// <summary>
        /// Gets dates associated with the selected holiday.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlHoliday_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid holidayItem;
            if (Guid.TryParse(ddlHoliday.SelectedValue, out holidayItem))
            {
                Item holiday = Sitecore.Context.Database.GetItem(new ID(holidayItem));

                if (holiday != null)
                {
                    PopulatDateDropDown(holiday);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="holiday"></param>
        private void PopulatDateDropDown(Item holiday)
        {
            ddlHolidayDate.Items.Clear();
            ddlHolidayDate.Items.Add(new ListItem("", ""));

            foreach (Item date in holiday.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.HolidayDate))
            {
                ddlHolidayDate.Items.Add(new ListItem(FieldRenderer.Render(date, fnPageHeading), date.ID.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Date
        {
            get;
            set;
        }

    }
}