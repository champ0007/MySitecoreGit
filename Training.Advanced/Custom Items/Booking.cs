using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.BaseCore.Fields.Mappings;
using Training.Utilities.Basecore.References;
using Sitecore.Links;
using Sitecore.Globalization;

namespace Training.Utilities.BaseCore.Mappings
{
    /// <summary>
    /// A custom item for the holiday template. For more information about custom items,
    /// see <see cref="Training.Utilities.BaseCore.Mappings.HolidayDate"/>.
    /// </summary>
    public class Booking : CustomItem
    {
        #region Constructors

        public Booking(Item innerItem) : base(innerItem) { }

        public static implicit operator Booking(Item innerItem)
        {
            return new Booking(innerItem);
        }

        #endregion

        #region Sitecore Fields

        private SitecoreTextField _firstName;
        public SitecoreTextField FirstName
        {
            get
            {
                if (_firstName == null)
                {
                    _firstName = new SitecoreTextField(this.InnerItem, "First Name");
                }

                return _firstName;
            }
        }

        private SitecoreTextField _surname;
        public SitecoreTextField Surname
        {
            get
            {
                if (_surname == null)
                {
                    _surname = new SitecoreTextField(this.InnerItem, "Surname");
                }

                return _surname;
            }
        }

        private SitecoreReferenceField _bookedDate;
        public SitecoreReferenceField BookedDate
        {
            get
            {
                if (_bookedDate == null)
                {
                    _bookedDate = new SitecoreReferenceField(this.InnerItem, "Booked Date");
                }
                return _bookedDate;
            }
        }

        #endregion
    }
}
