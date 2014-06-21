using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace Training.Utilities.BaseCore.Fields.Mappings
{
    /// <summary>
    /// The standard Sitecore field base class.
    /// </summary>
    public abstract class SitecoreField
    {
        protected string FieldName { get; set; }
        protected Item Item { get; set; }

        /// <summary>
        /// Depending on the field you are rendering, FieldRenderer accepts a number of parameters (particularly useful for images and dates).
        /// For more information, see: http://randombitsoftechnology.blogspot.co.uk/2011/03/sitecore-and-fieldrenderer.html
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Raw value - when you want to update a field, this is what you 'set'.
        /// </summary>
        private string _rawValue;
        public string RawValue 
        {
            get
            {
                _rawValue = String.Empty;

                if (IsValidField)
                {
                    _rawValue = Item[FieldName];
                }

                return _rawValue;
            }
            set
            {
                Item[FieldName] = value;
            }
        }

        /// <summary>
        /// The value as rendered by the FieldRenderer.Render method.
        /// </summary>
        public string RenderedValue 
        {
            get
            {
                string renderedValue = String.Empty;

                if (IsValidField)
                {
                    renderedValue = FieldRenderer.Render(Item, FieldName, (Parameters != null) ? Parameters : String.Empty);
                }

                return renderedValue;
            }
        }

        /// <summary>
        /// Checks if field has an item and a field name.
        /// </summary>
        public bool IsValidField
        {
            get
            {
                if (Item != null && !String.IsNullOrEmpty(FieldName))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
