using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore;


namespace Training.Utilities.BaseCore.Fields.Mappings
{
    /// <summary>
    /// A Sitecore 'Date' field.
    /// </summary>
    public class SitecoreDateField : SitecoreField, ISitecoreField
    {
        public SitecoreDateField(Item item, string fieldName)
        {
            this.FieldName = fieldName;
            this.Item = item;
        }

        /// <summary>
        /// The Sitecore date field.
        /// </summary>
        public DateField DateField
        {
            get
            {
                DateField dateField = null;

                if (IsValidField)
                {
                    dateField = Item.Fields[FieldName];
                }

                return dateField;
            }
        }

        /// <summary>
        /// Formatted date string.
        /// </summary>
        public string FormattedDate
        {
            get
            {
                string date = String.Empty;

                if (DateField != null)
                {
                    /* 'DateUtil' is one of many Sitecore utilities. For a full list, see:
                     * http://www.markstiles.net/Blog/2011/02/28/sitecore-util-classes.aspx
                     * Date is formatted this way to ensure that the format changes depending
                     * on Sitecore's context culture (determined by the context language).
                     */

                    return DateUtil.FormatDateTime(DateField.DateTime, "d", Sitecore.Context.Culture);
                }

                return date;
            }
        }
    }
}
