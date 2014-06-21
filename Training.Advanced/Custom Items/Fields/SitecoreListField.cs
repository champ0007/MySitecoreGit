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
    public class SitecoreListField : SitecoreField
    {
        public SitecoreListField(Item item, string fieldName)
        {
            this.FieldName = fieldName;
            this.Item = item;
        }

        private string _delimiter;
        public string Delimiter
        {
            get
            {
                if (!String.IsNullOrEmpty(_delimiter))
                {
                    return _delimiter;
                }

                return ",";
            }
            set
            {
                _delimiter = value;
            }
        }

        public MultilistField MultilistField
        {
            get
            {
                MultilistField multilistField = null;

                if (IsValidField)
                {
                    multilistField = Item.Fields[FieldName];
                }

                return multilistField;
            }
        }

        public List<Item> Items
        {
            get
            {
                List<Item> items = new List<Item>();

                if (MultilistField != null)
                {
                    items = MultilistField.GetItems().ToList();
                }

                return items;
            }
        }

        public string GetDelimitedList(string displayFieldName)
        {
            string list = String.Empty;

            if (Items.Any())
            {
                list = string.Join(Delimiter, Items.Select(x => (x != null) ? FieldRenderer.Render(x, displayFieldName) : String.Empty));
            }

            return list;
        }
    }
}
