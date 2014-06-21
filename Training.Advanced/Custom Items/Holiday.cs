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
    public class Holiday : CustomItem, IPageItem
    {
        #region Constructors

        public Holiday(Item innerItem) : base(innerItem) {}

        public static implicit operator Holiday(Item innerItem)
        {
            return new Holiday(innerItem);
        }

        #endregion

        #region Sitecore Fields

        private SitecoreTextField _title;
        public SitecoreTextField Title
        {
            get
            {
                if (_title == null)
                {
                    _title = new SitecoreTextField(this.InnerItem, "Page Heading");
                }

                return _title;
            }
        }

        private SitecoreListField _terrain;
        public SitecoreListField Terrain
        {
            get
            {
                if (_terrain == null)
                {
                    _terrain = new SitecoreListField(this.InnerItem, "Terrain");
                }
                
                return _terrain;
            }
        }

        private SitecoreReferenceField _type;
        public SitecoreReferenceField Type
        {
            get
            {
                if (_type == null)
                {
                    _type = new SitecoreReferenceField(this.InnerItem, "Type");
                }

                return _type;
            }
        }

        private SitecoreReferenceField _difficulty;
        public SitecoreReferenceField Difficulty
        {
            get
            {
                if (_difficulty == null)
                {
                    _difficulty = new SitecoreReferenceField(this.InnerItem, "Difficulty");
                }

                return _difficulty;
            }
        }

        #endregion

        #region Sitecore Properties 

        public string Url
        {
            get
            {
                return LinkManager.GetItemUrl(this.InnerItem);
            }
        }

        public IEnumerable<HolidayDate> Dates
        {
            get
            {
                return this.InnerItem.Children.Where(x => x.TemplateID == TemplateReferences.HolidayDate).Select(x => new HolidayDate(x));
            }
        }

        #endregion

        #region Temporary Properties

        public Dictionary<string, string> SummaryProperties
        {
            get
            {
                Dictionary<string, string> summaryProperties = new Dictionary<string, string>();

                summaryProperties.Add(Translate.Text("Difficulty"), (Difficulty.ReferenceItem != null) ? FieldRenderer.Render(Difficulty.ReferenceItem, "Text") : String.Empty);
                summaryProperties.Add(Translate.Text("Type"), (Type.ReferenceItem != null) ? FieldRenderer.Render(Type.ReferenceItem, "Text") : String.Empty);
                summaryProperties.Add(Translate.Text("Terrain"), Terrain.GetDelimitedList("Text"));

                return summaryProperties;
            }
        }
     
        #endregion 

        #region Sorting

        #endregion
    }
}
