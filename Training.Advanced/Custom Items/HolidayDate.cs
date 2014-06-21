using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.BaseCore.Fields.Mappings;
using Training.Utilities.Basecore.References;
using Sitecore.Links;

namespace Training.Utilities.BaseCore.Mappings
{
    /// <summary>
    /// 'HolidyDate' is a custom item. A custom item is a strongly typed template, with its key fields defined
    /// as a custom property (SitecoreField - this is not a Sitecore feature). There are also a number of other useful
    /// properties that check if e.g. there are any spaces left on this holiday, or if the holiday is currently bookable.
    /// 
    /// Using custom items means that any field strings are defined in a single place, and you do not have to use Sitecore
    /// controls to output content.
    /// 
    /// You can download a custom item generator that does all the work for you - this is just an example to show you how
    /// a custom item could be used.
    /// 
    /// For more information about Sitecore items, see: http://adeneys.wordpress.com/2010/06/25/custom-item-pattern/
    /// For the Custom Item Generator, see: http://blog.velir.com/index.php/category/sitecore/custom-item-generator/
    /// For the Custom Item Generator download, see: http://marketplace.sitecore.net/en/Modules/Custom_Item_Generator.aspx
    /// </summary>
    public class HolidayDate : CustomItem, IPageItem, IComparable
    {
        #region Constructors

        /* To access the plain Sitecore item, use this.InnerItem */

        public HolidayDate(Item innerItem) : base(innerItem) { }

        public static implicit operator HolidayDate(Item innerItem)
        {
            return new HolidayDate(innerItem);
        }

        #endregion

        #region Sitecore Fields

        /* Sitecore fields as a custom 'SitecoreField' class - you can get the rendered value, raw value,
         * or the actual field. This is similar to what the custom item generator (above) does.
         */

        private SitecoreTextField _maximumParticipants;
        public SitecoreTextField MaximumParticipants
        {
            get
            { 
                if (_maximumParticipants == null)
                {
                    _maximumParticipants = new SitecoreTextField(this.InnerItem, "Maximum Participants");
                }

                return _maximumParticipants;
            }
        }

        private SitecoreDateField _startDate;
        public SitecoreDateField StartDate
        {
            get
            {
                if (_startDate == null)
                {
                    _startDate = new SitecoreDateField(this.InnerItem, "Start Date");
                }
                
                return _startDate;
            }

        }

        private SitecoreDateField _endDate;
        public SitecoreDateField EndDate
        {
            get
            {
                if (_endDate == null)
                {
                    _endDate = new SitecoreDateField(this.InnerItem, "End Date");
                }

                return _endDate;
            }
        }

        #endregion

        #region Sitecore Properties 

        /* Sitecore data that is not a field - e.g. the 'bookings' children, or the item's URL. */

        private List<Item> _bookings;
        public List<Item> Bookings
        {
            get
            {
                _bookings = new List<Item>();

                Item bookingsFolder = this.InnerItem.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.BookingsFolder).FirstOrDefault();

                if (bookingsFolder != null)
                {
                    _bookings = bookingsFolder.Children.ToList();
                }

                return _bookings;
            }
            set
            {
                value = _bookings;
            }
        }

        public Holiday Holiday
        {
            get
            {
                return this.InnerItem.Axes.GetAncestors().Where(x => x.TemplateID == TemplateReferences.Holiday).Select(x => new Holiday(x)).FirstOrDefault();
            }
        }

        public string Url
        {
            get
            {
                return LinkManager.GetItemUrl(this.InnerItem);
            }
        }

        #endregion

        #region Temporary Properties

        /* Useful calculated properties. */

        public int Spaces
        {
            get
            {
                int maxParticipants;
                if (int.TryParse(MaximumParticipants.RawValue, out maxParticipants))
                {
                    return maxParticipants - Bookings.Count;
                }

                return maxParticipants;
            }
        }

        public bool StartDateAfterToday
        {
            get
            {
                if (StartDate.DateField.DateTime > DateTime.Today && StartDate.DateField.DateTime > DateTime.MinValue)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion 

        #region Sorting

        public int CompareTo(object obj)
        {
            HolidayDate h = (HolidayDate)obj;
            return StartDate.DateField.DateTime.CompareTo(h.StartDate.DateField.DateTime);
        }

        #endregion
    }
}
